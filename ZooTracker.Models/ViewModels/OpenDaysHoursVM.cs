using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooTracker.Models.Entity;

namespace ZooTracker.Models.ViewModels
{
    public class OpenDaysHoursVM
    {
        public OpenDaysHoursVM() { }

        public OpenDaysHoursVM(OpenDaysHours openDaysHours) 
        {
            this.Id = openDaysHours.Id;
            this.DayOfWeek = openDaysHours.DayOfWeek;
            this.IsOpen = openDaysHours.IsOpen;
            this.OpenTime = openDaysHours.OpenTime;
            this.CloseTime = openDaysHours.CloseTime;
        }

        public int? Id { get; set; }
        [Required]
        public string DayOfWeek {  get; set; }
        [Required]
        public bool IsOpen {  get; set; }
        
        public TimeOnly? OpenTime { get; set; }

        public TimeOnly? CloseTime { get; set; }
        public int ZooId { get; set; }

    }
}
