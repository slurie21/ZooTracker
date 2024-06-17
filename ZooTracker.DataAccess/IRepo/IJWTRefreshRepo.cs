using ZooTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooTracker.Models.Entity;

namespace ZooTracker.DataAccess.IRepo
{
    public interface IJWTRefreshRepo : IRepository<JWTRefreshToken>
    {
        Task<int> DeleteAllRefreshTokensByUserID(string userId);

    }
}
