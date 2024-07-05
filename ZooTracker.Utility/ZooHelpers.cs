using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using ZooTracker.Models.Entity;
using ZooTracker.Models.ViewModels;
using ZooTracker.Utility.Interface;

namespace ZooTracker.Utility
{
    public class ZooHelpers : IZooHelpers
    {
        public ZooAddress UpdateZooAddressFromVM(ZooAddress address, ZooAddressVM addressVM)
        {
            // Update address properties from view model
            address.Street1 = addressVM.Street1;
            address.Street2 = addressVM.Street2;
            address.City = addressVM.City;
            address.State = addressVM.State;
            address.Zip  = addressVM.Zip;
            return address;
        }

        public ZooAnimal UpdateZooAnimalFromVM(ZooAnimal animal, ZooAnimalVM animalVM)
        {
            animal.Name = animalVM.Name; 
            animal.FemaleNum = animalVM.FemaleNum;
            animal.MaleNum = animalVM.MaleNum;
            animal.TotalNum = animalVM.FemaleNum + animalVM.MaleNum;
            animal.IsActive = animalVM.IsActive;
            animal.Habitat = animalVM.Habitat;
            return animal;
        }

        public OpenDaysHours UpdateZooHoursFromVM(OpenDaysHours openDaysHours, OpenDaysHoursVM openDaysHoursVM)
        {
            openDaysHours.IsOpen = openDaysHoursVM.IsOpen;
            openDaysHours.OpenTime = openDaysHoursVM.OpenTime;
            openDaysHours.CloseTime = openDaysHoursVM.CloseTime;
            return openDaysHours;
        }

        public Zoo UpdateZooFromVM(Zoo zoo, ZooVM zooVM, string updatedBy)
        {
            zoo.Name = zooVM.Name;
            zoo.MainAttraction = zooVM.MainAttraction;
            zoo.TicketCost = zooVM.TicketCost;
            zoo.ChildTicket = zooVM.ChildTicket;
            zoo.SeniorTicket = zooVM.SeniorTicket;
            zoo.IsActive = zooVM.IsActive ?? true;
            zoo.ModifiedBy = updatedBy;
            zoo.ModifiedDate = DateTime.UtcNow;

            if (zoo.Address != null && zooVM.Address != null)
            {
                zoo.Address = UpdateZooAddressFromVM(zoo.Address, zooVM.Address);
            }

            // Update existing OpenDaysHours or add new ones
            if(zooVM.OpenDaysHours != null || zooVM.OpenDaysHours.Count == 7)
            {
                foreach (var day in zoo.OpenDaysHours)
                { 
                    var dayToUpdateFrom = zooVM.OpenDaysHours.FirstOrDefault(x => x.Id == day.Id);
                    UpdateZooHoursFromVM(day, dayToUpdateFrom);
                }
            }

            if(zooVM.Animals != null && zooVM.Animals.Count > 0)
            {
                //after updating animal remove it from the list and if there is anything left its a new animal
                var vmAnimalList = zooVM.Animals;
                foreach(var animal in zoo.Animals)
                {
                    var animalToUpdateFrom = vmAnimalList.FirstOrDefault(x => x.Id ==  animal.Id);
                    UpdateZooAnimalFromVM(animal, animalToUpdateFrom);
                    animal.ModifiedBy = updatedBy;
                    animal.ModifiedDate = DateTime.UtcNow;
                    vmAnimalList.Remove(animalToUpdateFrom);
                }

                if(vmAnimalList.Count > 0)
                {
                    foreach(var newAnimal in vmAnimalList)
                    {
                        newAnimal.CreatedBy = updatedBy;
                        zoo.Animals.Add(new ZooAnimal(newAnimal));
                    }
                }
            }
           
            return zoo;
        }
    }
}
