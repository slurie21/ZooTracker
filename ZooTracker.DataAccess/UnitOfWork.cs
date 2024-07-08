using ZooTracker.DataAccess.Context;
using ZooTracker.DataAccess.IRepo;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooTracker.Models.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace ZooTracker.DataAccess
{
    public class UnitOfWork : IUnitOfWork
    {
        private AppDbContext _db;

        public IJWTRefreshRepo JwtRefreshToken { get; private set; }
        public IJwtBlacklistTokenRepo JwtBlacklistToken { get; private set; }
        public IEnterpriseLoggingRepo EnterpriseLogging { get; private set; }
        public IZooRepo Zoos {  get; private set; }
        public IAddressRepo Address { get; private set; }
        public IOpenDaysHoursRepo OpenDaysHours { get; private set; }
        public IUserVMRepo UserVM { get; private set; }
        public IAnimalRepo Animals { get; private set; }

        public UnitOfWork(AppDbContext db)
        {
            _db = db;
            JwtRefreshToken = new JWTRefreshRepo(_db);
            JwtBlacklistToken = new JwtBlacklistTokenRepo(_db);
            EnterpriseLogging = new EnterpriseLoggingRepo(_db);
            Zoos = new ZooRepo(_db);
            Address = new AddressRepo(_db);
            OpenDaysHours = new OpenDaysHoursRepo(_db);
            UserVM = new UserVMRepo(_db);
            Animals = new AnimalRepo(_db);
        }

        public async Task Save()
        {
            await _db.SaveChangesAsync();
        }

        
    }
}
