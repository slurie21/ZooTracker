using ZooTracker.DataAccess.Context;
using ZooTracker.DataAccess.IRepo;
using ZooTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooTracker.Models.Entity;
using Microsoft.EntityFrameworkCore;
using ZooTracker.Models.ViewModels;

namespace ZooTracker.DataAccess
{
    public class UserVMRepo : IUserVMRepo
    {
        private AppDbContext _db;

        public UserVMRepo(AppDbContext db)
        {
            _db = db;
        }

        public async Task<List<UserVM>> GetUserVMsWithRole()
        {
            var userList = new List<UserVM>();

            string sql = "select users.Id as Id, " +
                "users.Fname as Fname, " +
                "users.Lname as Lname, " +
                "users.Email as Email, " +
                "users.IsActive as IsActive, " +
                "roles.Name as Role " +
                "from AspNetUsers users " +
                "left outer join AspNetUserRoles userroles " +
                "on users.Id = userroles.UserId " +
                "left outer join AspNetRoles roles " +
                "on userroles.RoleId = roles.Id ";
            userList = await _db.Database.SqlQueryRaw<UserVM>(sql).ToListAsync();
            return userList;
        }

        public async Task<UserVM> GetUserWithRole(string userID)
        {
            var user = new UserVM();

            string sql = "select users.Id as Id, " +
                "users.Fname as Fname, " +
                "users.Lname as Lname, " +
                "users.Email as Email, " +
                "users.IsActive as IsActive, " +
                "roles.Name as Role " +
                "from AspNetUsers users " +
                "left outer join AspNetUserRoles userroles " +
                "on users.Id = userroles.UserId " +
                "left outer join AspNetRoles roles " +
                "on userroles.RoleId = roles.Id ";
            if (!string.IsNullOrEmpty(userID))
            {
                sql += $" where users.Id = \'{userID}\'";
            }
            user = _db.Database.SqlQueryRaw<UserVM>(sql).FirstOrDefault();
            return user;
        }
    }
}
