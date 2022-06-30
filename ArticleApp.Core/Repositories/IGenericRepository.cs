using ArticleApp.Core.Models;

namespace ArticleApp.Core.Repositories
{
    public interface IGenericRepository<T> where T : class, IEntity, new()
    {
        Task<T> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
        Task AddAsync(T entity);
        void Update(T entity);
        void Remove(T entity);
    }
}