﻿using Microsoft.AspNetCore.Authorization;
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
        [Authorize(Roles ="Admin")]
        [GetGuidForLogging]
        public async Task<IActionResult> AddZoo([FromBody] ZooVM zooVM)
        {
            string correlationID = HttpContext.Items["correlationID"].ToString() ?? "";
            var userEmail = HttpContext.User.FindFirstValue(ClaimTypes.Email) ?? "User Email not found"; 
            Zoo zoo = new Zoo(zooVM);
            zoo.CreatedBy = userEmail;
            //zoo.CreatedDate = DateTime.UtcNow;
            zoo.Address.Created = DateTime.UtcNow;
            zoo.Address.CreateBy = userEmail;
            
            
            await _unitOfWork.Zoos.Add(zoo);
            _logger.LogInformation($"Zoo: {zoo.Name} with ID: {zoo.Id} added");
            await _unitOfWork.EnterpriseLogging.Add(new EnterpriseLogging { Area = "ZooController", Note = $"Zoo: {zoo.Name} with ID: {zoo.Id} added by {userEmail}", CorrelationID = correlationID });
            await _unitOfWork.Save();
            return Created(string.Empty, $"Zoo: {zoo.Name} created successfully"); //the first param should direct to where the resource can be access (get method)
        }

        [HttpGet("allzoos")]
        public async Task<IActionResult> GetAllZoos(string includeProperties = "Address,OpenDaysHours")
        {
            var userEmail = HttpContext.User.FindFirstValue(ClaimTypes.Email) ?? "User Email not found";
            _logger.LogInformation($"{userEmail} searched for all zoos");
            var zoos = _unitOfWork.Zoos.GetAll(includeProperties).Where(x => x.IsActive == true);
            var zooList = zoos.Select(z => new ZooVM
            {
                Id = z.Id,
                Name = z.Name,
                MainAttraction = z.MainAttraction,
                TicketCost = z.TicketCost,
                ChildTicket = z.ChildTicket,
                SeniorTicket = z.SeniorTicket,
                IsActive = z.IsActive,
                CreatedDate = z.CreatedDate,
                CreatedBy = z.CreatedBy,
                Address = new ZooAddressVM
                {
                    Id = z.Address.Id,
                    Street1 = z.Address.Street1,
                    Street2 = z.Address.Street2,
                    City = z.Address.City,
                    State = z.Address.State,
                    Zip = z.Address.Zip,
                    Created = z.Address.Created,
                    CreateBy = z.Address.CreateBy,
                    IsActive = z.Address.IsActive,
                    ZooId = z.Address.ZooId
                },
                OpenDaysHours = z.OpenDaysHours.Select(odh => new OpenDaysHoursVM
                {
                    Id = odh.Id,
                    DayOfWeek = odh.DayOfWeek,
                    IsOpen = odh.IsOpen,
                    OpenTime = odh.OpenTime,
                    CloseTime = odh.CloseTime,
                    ZooId = odh.ZooId
                }).ToList()
            }).ToList();
            return Ok(zooList);
        }
    }
}
