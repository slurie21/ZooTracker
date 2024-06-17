using ZooTracker.DataAccess.Context;
using ZooTracker.DataAccess.IRepo;
using ZooTracker.Models.DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooTracker.DataAccess
{
    public class JwtBlacklistTokenRepo : Repository<JwtBlacklistToken>, IJwtBlacklistTokenRepo
    {
        private AppDbContext _db;

        public JwtBlacklistTokenRepo(AppDbContext db) : base(db)
        {
            _db = db;
        }
    }
}
