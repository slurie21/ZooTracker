using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using ZooTracker.DataAccess.Context;
using ZooTracker.DataAccess.IRepo;
using ZooTracker.Filters.ActionFilters;
using ZooTracker.Models.Entity;
using ZooTracker.Models.ViewModels;

namespace ZooTracker.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    [Authorize]
    [ServiceFilter(typeof(Auth_ConfirmJtiNotBlacklistedFilterAttribute))]
    public class AccountController : ControllerBase
    {

        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<AccountController> _logger;

        public AccountController(UserManager<ApplicationUser> userManager, IUnitOfWork unitOfWork, ILogger<AccountController> logger)
        {
            _userManager = userManager;
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        [HttpPost("register")]
        [AllowAnonymous]
        [GetGuidForLogging]
        public async Task<IActionResult> Register([FromBody] RegistrationVM registrationVM)
        {
            //need first check to be if role is going to be admin and then make sure that the user is an admin.
            if(registrationVM.Role == null)
            {
                registrationVM.Role = "User";
            }
            if (!string.IsNullOrEmpty(registrationVM.Role) && registrationVM.Role.Equals("Admin", StringComparison.InvariantCultureIgnoreCase))
            {
                string userId = User.FindFirstValue("userID") ?? "0";
                if (userId == null || userId == "0") {
                    return BadRequest("No user ID in token");
                }

                ApplicationUser currentUser = await _userManager.FindByIdAsync(userId);
                bool isAdmin = await  _userManager.IsInRoleAsync(currentUser, "Admin");

                if (!isAdmin)
                {
                    return Forbid("Only Admin can register admin");
                }
            }

            string correlationID = HttpContext.Items["correlationID"].ToString() ?? "";

            _logger.LogInformation($"Starting process of creating new user and assigning roles. Correlation ID: {correlationID}");
            ApplicationUser newUser = new ApplicationUser(registrationVM);
            
            var createUserResult = await _userManager.CreateAsync(newUser, registrationVM.Password);
            if (createUserResult.Succeeded)
            {
                registrationVM.Id = newUser.Id;
                //Below is ok to leave because if adding Admin the user adding the new admin is already being confirmed
                await _userManager.AddToRoleAsync(newUser, registrationVM.Role);  //Add user or Admin depending on whats passed through.
                await _unitOfWork.EnterpriseLogging.Add(new EnterpriseLogging { App = "ZooTracker", Area = "Auth", Note = $"User {newUser.Fname + " " + newUser.Lname} has been created successfully.", CreatedDate = DateTime.UtcNow, CorrelationID = correlationID });
                _logger.LogInformation($"New user {registrationVM.Fname + " " + registrationVM.Lname} created successfully.");
            }
            else
            {
                var errors = createUserResult.Errors.Select(e => e.Description);
                var errorString = string.Join(", ", errors);
                await _unitOfWork.EnterpriseLogging.Add(new EnterpriseLogging { App = "ZooTracker", Area = "Auth", Note = $"User {newUser.Fname + " " + newUser.Lname} has failed to be created.", StackTrace = errorString, CreatedDate = DateTime.UtcNow, CorrelationID = correlationID });
                _logger.LogInformation($"User registration of {registrationVM.Fname + " " + registrationVM.Lname} had an issue.");
                await _unitOfWork.Save();
                return BadRequest(new { errors = createUserResult.Errors, user = registrationVM });
            }
            await _unitOfWork.Save();

            //generate a token to send back to the user along with a refresh token
            UserVM userVM = registrationVM.GetUserVM();
            return Created(string.Empty, userVM);
        }

        [HttpGet("users")]
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _unitOfWork.UserVM.GetUserVMsWithRole();
            return Ok(users);
        }

        [HttpPost("archive/{userID}")]
        [GetGuidForLogging]
        //[Admin_ValidateUserIdFilter]
        public async Task<IActionResult> Inactivate(string userID)
        {
            string loggedInUser = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name).Value;
            string correlationID = HttpContext.Items["correlationID"].ToString() ?? "";
            _logger.LogInformation($"attempting to inactivate User id: {userID}");

            var userToInactivate = await _userManager.FindByIdAsync(userID);

            if (userToInactivate != null)
            {
                userToInactivate.IsActive = false;
                userToInactivate.DeletedAt = DateTime.Now;

                var result = await _userManager.UpdateAsync(userToInactivate);

                if (User.Identity != null)
                {
                    if (result.Succeeded)
                    {
                        await _unitOfWork.EnterpriseLogging.Add(new EnterpriseLogging { App = "OrderEntryMangement", Area = "Admin", Note = $"{loggedInUser} archived user {userToInactivate.UserName}", CreatedDate = DateTime.UtcNow, CorrelationID = correlationID });
                        await _unitOfWork.Save();
                        _logger.LogInformation($"Successfully inactivated User id: {userID}");
                        return Ok(result);
                    }
                    else
                    {
                        await _unitOfWork.EnterpriseLogging.Add(new EnterpriseLogging { App = "OrderEntryMangement", Area = "Admin", Note = $"Failure of {loggedInUser} to archive user {userToInactivate.UserName}", CreatedDate = DateTime.UtcNow, CorrelationID = correlationID });
                        await _unitOfWork.Save();
                        _logger.LogError($"Failed to archived User id: {userID}");
                        ModelState.AddModelError("", "Error Deleting User.  Please try again");
                    }
                }
                else
                {
                    //TODO - should this be an exception or notfoundobjectresults
                    return BadRequest("Requesting User is not found in system");
                }
            }
            else
            {
                //errorcheck here for null userToInactivate
                //TODO - should this be an exception or notfoundobjectresults
                return BadRequest("User to inactivate is not found in system");
            }
            return Ok($"User {userID} has been inactivated");
        }



    }
}
