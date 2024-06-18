using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooTracker.Models.Entity
{
    public class OpenDaysHours
    {
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
        [ForeignKey("ZooId")]
        public Zoo Zoo { get; set; }
        #endregion
    }
}
