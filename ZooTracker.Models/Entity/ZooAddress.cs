using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooTracker.Models.ViewModels;

namespace ZooTracker.Models.Entity
{
    [Table("ZooAddress", Schema = "Zoo")]
    public class ZooAddress
    {
        public ZooAddress() { }

        public ZooAddress(ZooAddressVM zooAddressVM)  //not updating created and createby since those dont matter after initial creation
        {
            this.Street1 = zooAddressVM.Street1;
            this.Street2 = zooAddressVM.Street2;
            this.City = zooAddressVM.City;
            this.State = zooAddressVM.State;
            this.Zip = zooAddressVM.Zip;
            this.IsActive = zooAddressVM.IsActive;
        }

        [Key]
        public int Id { get; set; }
        [Required]
        public string Street1 { get; set; }
        public string? Street2 { get; set; }
        [Required]
        public string City {  get; set; }
        [Required]
        public string State { get; set; }
        [Required]
        public string Zip { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; }
        [Required]
        public string CreatedBy { get; set; }
        [Required]
        public bool IsActive {  get; set; } 

        #region Navigation Properties
        public int ZooId {  get; set; }

        //[ForeignKey("ZooId")]
        //public Zoo Zoo { get; set; }
        #endregion
    }
}
