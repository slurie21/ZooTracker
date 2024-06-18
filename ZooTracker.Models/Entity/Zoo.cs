using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooTracker.Models.ViewModels;

namespace ZooTracker.Models.Entity
{
    [Table("Zoos",Schema ="Zoo")]
    public class Zoo
    {
        public Zoo() { }

        public Zoo(ZooVM zooVM) 
        { 
            Name = zooVM.Name;
            MainAttraction = zooVM.MainAttraction;
            TicketCost = zooVM.TicketCost;
            ChildTicket = zooVM.ChildTicket;
            SeniorTicket = zooVM.SeniorTicket;
            Address = zooVM.Address;
            OpenDaysHours = zooVM.OpenDaysHours;
        }

        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string? MainAttraction { get; set; }
        [Required]
        public double TicketCost {  get; set; }
        public double? ChildTicket {  get; set; }
        public double? SeniorTicket {  get; set; }
        [Required]
        public ZooAddress Address { get; set; }
        [Required]
        public List<OpenDaysHours> OpenDaysHours { get; set; }
    }
}
