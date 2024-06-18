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

        public ZooVM(Zoo zoo)
        {
            Id = zoo.Id;
            Name = zoo.Name;
            MainAttraction = zoo.MainAttraction;
            TicketCost = zoo.TicketCost;
            ChildTicket = zoo.ChildTicket;
            SeniorTicket = zoo.SeniorTicket;
            Address = zoo.Address;
            OpenDaysHours = zoo.OpenDaysHours;

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
        [Required(ErrorMessage ="Zoo Must Have an address")]
        public ZooAddress Address { get; set; }
        [Required(ErrorMessage ="Zoo must have opening and closing times")]
        public List<OpenDaysHours> OpenDaysHours { get; set; } = new List<OpenDaysHours>();
    }
}
