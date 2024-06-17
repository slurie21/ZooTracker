using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooTracker.Models.Entity
{
    [Table("JwtRefresh")]
    public class JWTRefreshToken
    {
        public JWTRefreshToken() { }

        public JWTRefreshToken(string refreshToken, string userID) 
        {
            UserId = userID;
            Token = refreshToken;
        }

        [Key]
        public int ID { get; set; }
        [Required]
        public string UserId { get; set; }
        [Required]
        public string Token { get; set; }
        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        [Required]
        public DateTime ExpiresAt { get; set; } = DateTime.UtcNow.AddDays(15);
        
    }
}
