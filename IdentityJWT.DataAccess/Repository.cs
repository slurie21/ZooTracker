﻿using IdentityJWT.DataAccess.Context;
using IdentityJWT.DataAccess.IRepo;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace IdentityJWT.DataAccess
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly AppDbContext _db;
        internal DbSet<T> dbSet;

        public Repository(AppDbContext db)
        {
            _db = db;
            this.dbSet = _db.Set<T>();
        }

        public async Task<bool> Add(T entity)
        {
                await dbSet.AddAsync(entity);
                return true;
            
        }

        public async Task<bool> Update(T entity)
        {
            dbSet.Update(entity);
            return true;
        }

        public async Task<bool> Remove(T entity)
        {
                dbSet.Remove(entity);
                return true;
            
        }

        public async Task<int> DeleteUsingFilter(T entity, Func<T, bool> filter)
        {
            int result = await dbSet.ExecuteDeleteAsync();
            return result;
        }

        public void DeleteRange(IEnumerable<T> entities)
        {
            //this needs to inactivate not truly delete
            throw new NotImplementedException();
        }

        public T Get(Expression<Func<T, bool>> filter, string? includeProperties = null)
        {
            IQueryable<T> query = dbSet;
            query = query.Where(filter);
            if (!string.IsNullOrEmpty(includeProperties))
            {
                foreach (var includeProp in includeProperties
                    .Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProp);
                }
            }
            return query.FirstOrDefault();
        }

        public IEnumerable<T> GetAll(string? includeProperties = null)
        {
            IQueryable<T> query = dbSet;
            if (!string.IsNullOrEmpty(includeProperties))
            {
                foreach (var includeProp in includeProperties
                    .Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProp);
                }
            }

            return query.ToList();
        }
    }
}
