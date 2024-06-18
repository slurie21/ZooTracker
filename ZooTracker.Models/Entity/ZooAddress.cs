using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooTracker.Models.Entity
{
    [Table("ZooAddress", Schema = "Zoo")]
    public class ZooAddress
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Street1 { get; set; }
        [AllowNull]
        public string? Street2 { get; set; }
        [Required]
        public string City {  get; set; }
        [Required]
        public string State { get; set; }
        [Required]
        public string Zip { get; set; }

        public DateTime Created { get; set; }

        public string CreateBy { get; set; }

        public bool IsActive {  get; set; } 

        #region Navigation Properties
        public int ZooId {  get; set; }

        [ForeignKey("ZooId")]
        public Zoo Zoo { get; set; }
        #endregion
    }
}
