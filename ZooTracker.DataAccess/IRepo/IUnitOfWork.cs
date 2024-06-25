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
        IZooRepo Zoos {get; }
        IAddressRepo Address { get; }
        IOpenDaysHoursRepo OpenDaysHours { get; }
        Task Save();
    }
}
