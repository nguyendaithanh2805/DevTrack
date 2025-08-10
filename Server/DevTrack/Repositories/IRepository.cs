using System.Linq.Expressions;

namespace DevTrack.Repositories
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> FindAllAsync();
        Task<IEnumerable<T>> FindWithExpressionAsync(Expression<Func<T, bool>> predicate);
        Task<T> FindAsync(int id);
        Task AddAsync(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
