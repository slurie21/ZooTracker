
using ZooTracker.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooTracker.Utility.Interface
{
    public interface IJwtManager
    {
        (string token, string refreshToken) GenerateJwtandRefreshToken(ApplicationUser user, List<string> roles);
        string GenerateJwtToken(ApplicationUser user, List<string> roles);
        string RefreshTokenGenerator();
        Task<bool> RefreshTokenValidate(string refreshToken);

    }
}
