using ZooTracker.DataAccess.Context;
using ZooTracker.DataAccess.IRepo;
using ZooTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooTracker.Models.Entity;

namespace ZooTracker.DataAccess
{
    public class OpenDaysHoursRepo : Repository<OpenDaysHours>, IOpenDaysHoursRepo
    {
        private AppDbContext _db;

        public OpenDaysHoursRepo(AppDbContext db) : base(db)
        {
            _db = db;
        }
    }
}
