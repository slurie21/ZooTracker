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
            if(!onlyZoo)
            {
                if(zoo.Address != null)
                {
                    Address = new ZooAddressVM(zoo.Address);
                }
                if(zoo.OpenDaysHours != null) 
                {
                    OpenDaysHours = new List<OpenDaysHoursVM>(zoo.OpenDaysHours.Select(x => new OpenDaysHoursVM(x))); ;
                }
                if (zoo.Animals != null)
                {
                    Animals = new List<ZooAnimalVM>(zoo.Animals.Select(x => new ZooAnimalVM(x)));
                }
            }
        }


        public int? Id { get; set; }

        public string Name { get; set; }
        public string? MainAttraction { get; set; }
        public double TicketCost { get; set; }
        public double? ChildTicket { get; set; }
        public double? SeniorTicket { get; set; }
        public bool? IsActive {  get; set; }
       
        public DateTime? CreatedDate { get; set; }

        public string? CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string? ModifiedBy { get; set; }

        public ZooAddressVM? Address { get; set; } 
        public List<OpenDaysHoursVM>? OpenDaysHours { get; set; } 
        public List<ZooAnimalVM>? Animals { get; set; }
    }
}
