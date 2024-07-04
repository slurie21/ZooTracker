using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooTracker.Models.ViewModels;

namespace ZooTracker.Models.Entity
{
    [Table("Animals", Schema = "Zoo")]
    public class ZooAnimal
    {
        public ZooAnimal() { }
        public ZooAnimal(ZooAnimalVM zooAnimal)
        {
            this.Id = zooAnimal.Id;
            this.Name = zooAnimal.Name;
            this.FemaleNum = zooAnimal.FemaleNum;
            this.MaleNum = zooAnimal.MaleNum;
            this.TotalNum = zooAnimal.TotalNum;
            this.IsActive = zooAnimal.IsActive;
            this.Habitat = zooAnimal.Habitat;
            this.ZooId = zooAnimal.ZooId;
            this.CreatedDate = zooAnimal.CreatedDate ?? DateTime.UtcNow;
            this.CreatedBy = zooAnimal.CreatedBy;
            this.ModifiedBy = zooAnimal.ModifiedBy;
            this.ModifiedDate = zooAnimal.ModifiedDate;
        }
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public int FemaleNum { get; set; }
        public int MaleNum { get; set; }
        public int TotalNum { get; set; }
        [Required]
        public bool IsActive { get; set; } = true;
        public string? Habitat { get; set; }
        public int ZooId { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string? ModifiedBy { get; set; }

    }
}
