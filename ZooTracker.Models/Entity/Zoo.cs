using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooTracker.Models.ViewModels;

namespace ZooTracker.Models.Entity
{
    
    [Table("Zoos",Schema ="Zoo")]
    [Index(nameof(Zoo.Name),IsUnique = true)]
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
            IsActive = zooVM.IsActive;
            CreatedBy = zooVM.CreatedBy;
            CreatedDate = zooVM.CreatedDate;
            Address = new ZooAddress(zooVM.Address);
            OpenDaysHours = new List<OpenDaysHours>(zooVM.OpenDaysHours.Select(x => new OpenDaysHours(x)));
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
        public bool IsActive { get; set; } = true;

        [Required]
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        [Required]
        public string CreatedBy { get; set; }

        [Required]
        public ZooAddress Address { get; set; }
        [Required]
        public List<OpenDaysHours> OpenDaysHours { get; set; }
    }
}
