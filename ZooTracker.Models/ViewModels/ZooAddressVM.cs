using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooTracker.Models.Entity;

namespace ZooTracker.Models.ViewModels
{
    public class ZooAddressVM
    {
        public ZooAddressVM() { }  

        public ZooAddressVM(ZooAddress zooAddress)
        {
            this.Id = zooAddress.Id;
            this.Street1 = zooAddress.Street1;
            this.Street2 = zooAddress.Street2;
            this.City = zooAddress.City;
            this.State = zooAddress.State;
            this.Zip = zooAddress.Zip;
            this.CreatedDate = zooAddress.CreatedDate;
            this.CreateBy = zooAddress.CreateBy;
            this.IsActive = zooAddress.IsActive;

        }

        public int? Id { get; set; }
        [Required]
        public string Street1 { get; set; }
        public string? Street2 { get; set; }
        [Required]
        public string City {  get; set; }
        [Required]
        public string State { get; set; }
        [Required]
        public string Zip { get; set; }

        public DateTime? CreatedDate { get; set; }

        public string? CreateBy { get; set; }

        public bool IsActive { get; set; } = true;
        public int ZooId { get; set; }
    }
}
