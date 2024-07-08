using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ComicBookCrud.DataAccess.Data;
using ComicBookCrud.DataAccess.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace ComicBookCrud.DataAccess.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {

        private readonly ComicCrudDbContext _dbContext;
        internal DbSet<T> dbSet;
        public Repository(ComicCrudDbContext dbContext)
        {
            _dbContext = dbContext;
            this.dbSet = _dbContext.Set<T>();
        }

        public void Add(T entity)
        {
            dbSet.Add(entity);
        }

        public T Get(Expression<Func<T, bool>> filter)
        {
            IQueryable<T> query = dbSet;
            query = query.Where(filter);
            return query.FirstOrDefault();
        }

        public IEnumerable<T> GetAll()
        {
            IQueryable<T> query = dbSet;
            return query.ToList();
        }

        public void Remove(T entity)
        {
            dbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            dbSet.RemoveRange(entities);
        }
    }
}
