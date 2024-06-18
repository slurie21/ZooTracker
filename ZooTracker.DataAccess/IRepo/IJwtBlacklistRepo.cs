using ZooTracker.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooTracker.DataAccess.IRepo
{
    public interface IJwtBlacklistTokenRepo : IRepository<JwtBlacklistToken>
    {
    }
}
