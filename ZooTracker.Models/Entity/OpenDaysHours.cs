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
    [Table("OpenDaysHours", Schema = "Zoo")]
    public class OpenDaysHours
    {
        public OpenDaysHours() { }

        public OpenDaysHours(OpenDaysHoursVM openDaysHoursVM)
        {
            this.Id = openDaysHoursVM.Id ?? 0;
            this.DayOfWeek = openDaysHoursVM.DayOfWeek;
            this.IsOpen = openDaysHoursVM.IsOpen;
            this.OpenTime = openDaysHoursVM.OpenTime;
            this.CloseTime = openDaysHoursVM.CloseTime;
        }

        [Key]
        public int Id { get; set; }
        [Required]
        public string DayOfWeek {  get; set; }
        [Required]
        public bool IsOpen {  get; set; }
        
        public TimeOnly? OpenTime { get; set; }

        public TimeOnly? CloseTime { get; set; }


        #region Navigation Properties
        public int ZooId {  get; set; }
        //[ForeignKey("ZooId")]
        //public Zoo Zoo { get; set; }
        #endregion
    }
}
