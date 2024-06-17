using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooTracker.DataAccess.IRepo
{
    public interface IUnitOfWork
    {
        IJWTRefreshRepo JwtRefreshToken { get; }
        IJwtBlacklistTokenRepo JwtBlacklistToken { get; }
        IEnterpriseLoggingRepo EnterpriseLogging { get; }
        Task Save();
    }
}
