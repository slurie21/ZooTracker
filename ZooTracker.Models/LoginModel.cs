using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ZooTracker.Models
{
    public class LoginModel
    {
        [Required]
        public string Email { get; set; }
        [Required]
        [PasswordPropertyText]
        public string Password { get; set; }

        [DefaultValue(false)]
        public bool RememberMe { get; set; }

    }
}
