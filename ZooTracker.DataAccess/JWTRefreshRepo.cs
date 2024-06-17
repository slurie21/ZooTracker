﻿using ZooTracker.DataAccess.IRepo;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ZooTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooTracker.DataAccess.Context;

namespace ZooTracker.DataAccess
{
    public class JWTRefreshRepo : Repository<JWTRefreshToken>, IJWTRefreshRepo
    {
        private AppDbContext _db;

        public JWTRefreshRepo(AppDbContext db) : base(db)
        {
            _db = db;
        }

        public async Task<int> DeleteAllRefreshTokensByUserID(string userId)
        {
            int result = await _db.JwtRefreshToken.Where(x => x.UserId.Equals(userId)).ExecuteDeleteAsync();
            return result;
        }
    }
}
