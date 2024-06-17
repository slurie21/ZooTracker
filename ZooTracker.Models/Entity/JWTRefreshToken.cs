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
        public string UserId { get; set; }
        public string Token { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime ExpiresAt {  get; set; }
        
    }
}
