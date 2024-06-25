using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
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
            this.IsActive = user.IsActive;
        }

        [JsonPropertyName("Id")]
        public string? Id { get; set; }

        [JsonPropertyName("Fname")]
        [Required(ErrorMessage ="First Name must be supplied")]
        public string Fname { get; set; }

        [JsonPropertyName("Lname")]
        [Required(ErrorMessage = "Last Name must be supplied")]
        public string Lname { get; set; }

        [JsonPropertyName("Email")]
        [Required(ErrorMessage = "Email must be supplied")]
        public string Email { get; set; }
        public bool IsActive { get; set; }
        public string Role { get; set; } = "User";
    }
}