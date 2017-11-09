using Microsoft.EntityFrameworkCore;
using service.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace service.repository
{
    public class RepositoryBase<T> : IRepository<T> where T : class
    {
        private readonly DBHelperContext _context = null;
        private readonly DbSet<T> _dbSet;
        public RepositoryBase(DBHelperContext context)
        {
            this._context = context;
            this._dbSet = this._context.Set<T>();
        }

        public long Count()
        {
            return _dbSet.LongCount();
        }

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }

        public T Get(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.FirstOrDefault(predicate);
        }

        public IQueryable<T> GetAllList(Expression<Func<T, bool>> predicate = null)
        {
            if (predicate == null)
            {
                return _dbSet;
            }
            return _dbSet.Where(predicate);
        }

        public void Insert(T entity)
        {
            _dbSet.Add(entity);
        }

        public void Update(T entity)
        {
            _dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }
    }
}
