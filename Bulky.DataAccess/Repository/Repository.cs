
using System.Linq.Expressions;
using Bulky.DataAcess.Data;
using Bulky.DataAcess.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace Bulky.DataAccess.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _db;
        internal DbSet<T> dbSet;
        public Repository(ApplicationDbContext db)
        {
            _db = db;
            this.dbSet = _db.Set<T>();
            _db.Products.Include(u => u.Category).Include(u => u.CategoryId);
        }
       
        public void Add(T entity)
        {
           dbSet.Add(entity);
        }

        public T Get(Expression<Func<T, bool>> filter, string? includelProperties = null)
        {
            IQueryable<T> query = dbSet;
            query = query.Where(filter);
            if(!string.IsNullOrEmpty(includelProperties))
            {
                foreach(var includelProp in includelProperties
                    .Split(new char[]{','}, StringSplitOptions.RemoveEmptyEntries))
                    {
                        query = query.Include(includelProp);
                    }
            }
            return query.FirstOrDefault();
        }

        public IEnumerable<T> GetAll(string? includelProperties = null)
        {
            IQueryable<T> query = dbSet;
            if(!string.IsNullOrEmpty(includelProperties))
            {
                foreach(var includelProp in includelProperties
                    .Split(new char[]{','}, StringSplitOptions.RemoveEmptyEntries))
                    {
                        query = query.Include(includelProp);
                    }
            }
            return query.ToList();
        }

        public void Remove(T entity)
        {
            dbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entity)
        {
            dbSet.RemoveRange(entity);
        }
    }
}