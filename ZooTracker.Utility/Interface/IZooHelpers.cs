using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooTracker.Models.Entity;
using ZooTracker.Models.ViewModels;

namespace ZooTracker.Utility.Interface
{
    public interface IZooHelpers
    {
        Zoo UpdateZooFromVM(Zoo zoo, ZooVM zooVM);
        ZooAddress UpdateZooAddressFromVM(ZooAddress address, ZooAddressVM addressVM);
    }
}
