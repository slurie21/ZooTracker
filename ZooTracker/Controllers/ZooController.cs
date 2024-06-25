using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using ZooTracker.DataAccess.IRepo;
using ZooTracker.Filters.ActionFilters;
using ZooTracker.Models.Entity;
using ZooTracker.Models.ViewModels;

namespace ZooTracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    [ServiceFilter(typeof(Auth_ConfirmJtiNotBlacklistedFilterAttribute))]
    public class ZooController : ControllerBase
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<AccountController> _logger;

        public ZooController(IUnitOfWork unitOfWork, ILogger<AccountController> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        [HttpPost("add")]
        [GetGuidForLogging]
        public async Task<IActionResult> AddZoo([FromBody] ZooVM zooVM)
        {
            string correlationID = HttpContext.Items["correlationID"].ToString() ?? "";
            var userEmail = HttpContext.User.FindFirstValue(ClaimTypes.Email) ?? "User Email not found"; 
            Zoo zoo = new Zoo(zooVM);
            zoo.Address.Created = DateTime.UtcNow;
            zoo.Address.CreateBy = userEmail;
            
            await _unitOfWork.Zoos.Add(zoo);
            _logger.LogInformation($"Zoo: {zoo.Name} with ID: {zoo.Id} added");
            await _unitOfWork.EnterpriseLogging.Add(new EnterpriseLogging { Area = "ZooController", Note = $"Zoo: {zoo.Name} with ID: {zoo.Id} added by {userEmail}", CorrelationID = correlationID });
            await _unitOfWork.Save();
            return Created(string.Empty, $"Zoo: {zoo.Name} created successfully"); //the first param should direct to where the resource can be access (get method)
        }
    }
}
