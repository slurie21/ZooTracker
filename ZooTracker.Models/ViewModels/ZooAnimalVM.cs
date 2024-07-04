using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooTracker.Models.Entity;

namespace ZooTracker.Models.ViewModels
{
    public class ZooAnimalVM
    {
        public ZooAnimalVM() { }
        public ZooAnimalVM(ZooAnimal zooAnimal)
        {
            this.Id = zooAnimal.Id;
            this.Name = zooAnimal.Name;
            this.FemaleNum = zooAnimal.FemaleNum;
            this.MaleNum = zooAnimal.MaleNum;
            this.TotalNum = zooAnimal.TotalNum;
            this.IsActive = zooAnimal.IsActive;
            this.Habitat = zooAnimal.Habitat;
            this.ZooId = zooAnimal.ZooId;
            this.CreatedDate = zooAnimal.CreatedDate;
            this.CreatedBy = zooAnimal.CreatedBy;
            this.ModifiedBy = zooAnimal.ModifiedBy;
            this.ModifiedDate = zooAnimal.ModifiedDate;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int FemaleNum { get; set; }
        public int MaleNum { get; set; }
        public int TotalNum { get; set; }
        public bool IsActive { get; set; }
        public string? Habitat { get; set; }
        public int ZooId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string? ModifiedBy { get; set; }

    }
}
