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

        public Zoo UpdateZooFromVM(Zoo zoo, ZooVM zooVM)
        {
            zoo.Name = zooVM.Name;
            zoo.MainAttraction = zooVM.MainAttraction;
            zoo.TicketCost = zooVM.TicketCost;
            zoo.ChildTicket = zooVM.ChildTicket;
            zoo.SeniorTicket = zooVM.SeniorTicket;
            zoo.IsActive = zooVM.IsActive ?? true;
            zoo.CreatedBy = zooVM.CreatedBy ?? "Lost Created by during update";
            zoo.CreatedDate = zooVM.CreatedDate ?? zoo.CreatedDate;

            if (zoo.Address != null && zooVM.Address != null)
            {
                zoo.Address = UpdateZooAddressFromVM(zoo.Address, zooVM.Address);
            }

            if (zoo.OpenDaysHours == null)
            {
                zoo.OpenDaysHours = new List<OpenDaysHours>();
            }

            // Update existing OpenDaysHours or add new ones
            if(zooVM.OpenDaysHours != null || zooVM.OpenDaysHours.Count > 0)
            {
                zoo.OpenDaysHours.Clear();
                foreach (var openDayHour in zooVM.OpenDaysHours)
                {
                    zoo.OpenDaysHours.Add(new OpenDaysHours(openDayHour));
                }
            }
           
            return zoo;
        }
    }
}
