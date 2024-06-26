﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Mono.TextTemplating;
using System.IO;
using System.Reflection.Emit;
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
        private readonly ILogger<ZooController> _logger;

        //TODO: Create an audit table for tracking changes
        public ZooController(IUnitOfWork unitOfWork, ILogger<ZooController> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        [HttpPost("add")]
        [Authorize(Roles = "Admin")]
        [GetGuidForLogging]
        public async Task<IActionResult> AddZoo([FromBody] ZooVM zooVM)
        {
            string correlationID = HttpContext.Items["correlationID"].ToString() ?? "";
            var userEmail = HttpContext.User.FindFirstValue(ClaimTypes.Email) ?? "User Email not found";
            Zoo zoo = new Zoo(zooVM);
            zoo.Address.CreatedDate = DateTime.UtcNow;
            zoo.CreatedBy = userEmail;
            zoo.Address.CreateBy = userEmail;

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
        public async Task<IActionResult> GetAllZoos(string includeProperties = "Address,OpenDaysHours", bool includeInactive = false)
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
        public async Task<IActionResult> GetZoo(int id, string includeProperties = "Address,OpenDaysHours")
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

            var zooToUpdate = _unitOfWork.Zoos.Get(x => x.Id == id);

            return Ok();
        }

        

    }
}
