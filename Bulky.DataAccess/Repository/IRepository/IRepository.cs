

using System.Linq.Expressions;

namespace Bulky.DataAcess.Repository.IRepository
{
    public interface IRepository<T> where T : class 
    {
        IEnumerable<T> GetAll(string? includelProperties = null);
        T Get(Expression<Func<T, bool>> filter, string? includelProperties = null);
        void Add(T entity);
        // void Update(T entity);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entity);
    }
}