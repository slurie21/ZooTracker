using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Mono.TextTemplating;
using System.IO;
using System.Reflection.Emit;
using System.Security.Claims;
using ZooTracker.DataAccess.IRepo;
using ZooTracker.Filters.ActionFilters;
using ZooTracker.Models.Entity;
using ZooTracker.Models.ViewModels;
using ZooTracker.Utility.Interface;

namespace ZooTracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    [ServiceFilter(typeof(Auth_ConfirmJtiNotBlacklistedFilterAttribute))]
    public class ZooController : ControllerBase
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<ZooController> _logger;
        private readonly IZooHelpers _zooHelpers;
        //TODO: Create an audit table for tracking changes
        public ZooController(IUnitOfWork unitOfWork, ILogger<ZooController> logger, IZooHelpers zooHelpers)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _zooHelpers = zooHelpers;
            
        }

        [HttpPost("add")]
        [Authorize(Roles = "Admin")]
        [GetGuidForLogging]
        public async Task<IActionResult> AddZoo([FromBody] ZooVM zooVM)
        {
            string correlationID = HttpContext.Items["correlationID"].ToString() ?? "";
            var userEmail = HttpContext.User.FindFirstValue(ClaimTypes.Email) ?? "User Email not found";
            //zooVM.CreatedBy = userEmail;
            //zooVM.CreatedDate = DateTime.UtcNow;
            Zoo zoo = new Zoo(zooVM);
            zoo.Address.CreatedDate = DateTime.UtcNow;
            zoo.CreatedBy = userEmail;
            zoo.Address.CreatedBy = userEmail;
            zoo.Animals.ForEach(x =>
                {
                    x.CreatedBy = userEmail;
                    x.TotalNum = x.FemaleNum + x.MaleNum;
                }
            );
            try
            {
                await _unitOfWork.Zoos.Add(zoo);
                _logger.LogInformation($"Zoo: {zoo.Name} with ID: {zoo.Id} added");
                await _unitOfWork.EnterpriseLogging.Add(new EnterpriseLogging { Area = "ZooController", Note = $"Zoo: {zoo.Name} with ID: {zoo.Id} added by {userEmail}", CorrelationID = correlationID });
                await _unitOfWork.Save();
            } catch (Exception e) 
            {

                return BadRequest(new { innerException = e.InnerException.ToString(), issue = "Duplicate Name"});
            }

            
            return Created(string.Empty, $"Zoo: {zoo.Name} created successfully"); //the first param should direct to where the resource can be access (get method)
        }

        [HttpGet("allzoos")]
        public async Task<IActionResult> GetAllZoos(string includeProperties = "Address,OpenDaysHours,Animals", bool includeInactive = false)
        {
            var userEmail = HttpContext.User.FindFirstValue(ClaimTypes.Email) ?? "User Email not found";
            _logger.LogInformation($"{userEmail} searched for all zoos");
            var zoosList = (_unitOfWork.Zoos.GetAll(includeProperties)).Select(x => new ZooVM(x));
            if (!includeInactive)
            {
                return Ok(zoosList.Where(x => x.IsActive == true));
            }
            return Ok(zoosList);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetZoo(int id, string includeProperties = "Address,OpenDaysHours,Animals")
        {
            var zoo = (_unitOfWork.Zoos.Get(x => x.Id == id, includeProperties));
            return Ok(zoo);
        }

        [HttpPut("update/{id}")]
        [Authorize(Roles = "Admin")]
        [GetGuidForLogging]
        public async Task<IActionResult> UpdateZoo(int id, [FromBody] ZooVM zoo)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid ID");
            }
            var userEmail = HttpContext.User.FindFirstValue(ClaimTypes.Email) ?? "User Email not found";
            string correlationID = HttpContext.Items["correlationID"].ToString() ?? "";

            var zooToUpdate = _unitOfWork.Zoos.Get(x => x.Id == id, "Address,OpenDaysHours,Animals");
            if (zooToUpdate == null)
            {
                return BadRequest("No Zoo Found");
            }
            if (zoo.Id != zooToUpdate.Id)
            {
                return BadRequest("Check IDs of Zoo");
            }            
            try
            {
                _zooHelpers.UpdateZooFromVM(zooToUpdate, zoo, userEmail);
                await _unitOfWork.Zoos.Update(zooToUpdate);
                _logger.LogInformation($"Zoo: {zooToUpdate.Name} with ID: {zooToUpdate.Id} updated by {userEmail}");
                await _unitOfWork.EnterpriseLogging.Add(new EnterpriseLogging { Area = "ZooController", Note = $"Zoo: {zooToUpdate.Name} with ID: {zooToUpdate.Id} updated by {userEmail}", CorrelationID = correlationID });
                await _unitOfWork.Save();

                return Ok($"Zoo {id} updated");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.InnerException.ToString());
                await _unitOfWork.EnterpriseLogging.Add(new EnterpriseLogging { Area = "ZooController", Note = $"Error update Zoo: {zoo}", CorrelationID = correlationID });
                await _unitOfWork.Save();
                return BadRequest(ex.InnerException.ToString());
            }
        }
    }
}
