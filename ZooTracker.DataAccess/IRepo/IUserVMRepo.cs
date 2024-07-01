using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooTracker.Models.ViewModels;

namespace ZooTracker.DataAccess.IRepo
{
    public interface IUserVMRepo
    {
        Task<List<UserVM>> GetUserVMsWithRole();
        Task<UserVM> GetUserWithRole(string userID);
    }
}
