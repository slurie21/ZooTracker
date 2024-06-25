using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using ZooTracker.Models.Entity;

namespace ZooTracker.Models.ViewModels
{
    public class ZooVM
    {
        public ZooVM() { }

        public ZooVM(Zoo zoo, bool onlyZoo = false)
        {
            Id = zoo.Id;
            Name = zoo.Name;
            MainAttraction = zoo.MainAttraction;
            TicketCost = zoo.TicketCost;
            ChildTicket = zoo.ChildTicket;
            SeniorTicket = zoo.SeniorTicket;
            IsActive = zoo.IsActive;
            CreatedBy = zoo.CreatedBy;
            CreatedDate = zoo.CreatedDate;
            if (!onlyZoo)
            {
                Address = new ZooAddressVM(zoo.Address);
                OpenDaysHours = new List<OpenDaysHoursVM>(zoo.OpenDaysHours.Select(x => new OpenDaysHoursVM(x))); ;
            }
            
        }


        public int? Id { get; set; }
        [Required(ErrorMessage ="Zoo Name is required.")]
        [JsonPropertyName("ZooName")]
        public string Name { get; set; }
        public string? MainAttraction { get; set; }
        [Required(ErrorMessage ="You must enter a cost.  If free enter 0")]
        public double TicketCost { get; set; }
        public double? ChildTicket { get; set; }
        public double? SeniorTicket { get; set; }
        public bool IsActive { get; set; } = true;

        public DateTime? CreatedDate { get; set; }

        public string? CreatedBy { get; set; }
        [Required(ErrorMessage ="Zoo Must Have an address")]
        public ZooAddressVM Address { get; set; } 
        [Required(ErrorMessage ="Zoo must have opening and closing times")]
        public List<OpenDaysHoursVM> OpenDaysHours { get; set; } 
    }
}
