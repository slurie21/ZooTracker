using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooTracker.Models.Entity;

namespace ZooTracker.Models.ViewModels
{
    public class UserVM
    {
        public UserVM() { }
        public UserVM(ApplicationUser user)
        {
            this.Id = user.Id;
            this.Fname = user.Fname;
            this.Lname = user.Lname;
            this.Email = user.Email;
        }

        public string? Id { get; set; }

        [Required(ErrorMessage ="First Name must be supplied")]
        public string Fname { get; set; }
        [Required(ErrorMessage = "Last Name must be supplied")]
        public string Lname { get; set; }
        [Required(ErrorMessage = "Email must be supplied")]
        public string Email { get; set; }
        public string Role { get; set; } = "User";
    }
}