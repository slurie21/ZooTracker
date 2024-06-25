using ZooTracker.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooTracker.Models.Entity;

namespace ZooTracker.Models
{
    public class LoginResultModel
    {
        public LoginResultModel() { }

        public LoginResultModel(ApplicationUser user, string token, string refreshToken)
        {
            LoggedIn = true;
            User = new UserVM
            {
                Fname = user.Fname,
                Lname = user.Lname,
                Email = user.Email ?? "",
                Id = user.Id,
                IsActive = user.IsActive
            };
            Token = token;
            RefreshToken = refreshToken;
        }

        public bool LoggedIn { get; set; } = false;

        public UserVM? User { get; set; }
        public string? Token { get; set; }
        public string? RefreshToken { get; set; }
    }
}
