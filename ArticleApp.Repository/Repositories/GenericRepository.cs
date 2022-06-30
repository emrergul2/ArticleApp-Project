using ArticleApp.Core.Models;
using ArticleApp.Core.Repositories;
using ArticleApp.Repository.Contexts;
using Microsoft.EntityFrameworkCore;

namespace ArticleApp.Service.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class, IEntity, new()
    {
        protected readonly ArticleAppDbContext _dbContext;
        private readonly DbSet<T> _dbSet;

        public GenericRepository(ArticleAppDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<T>();
        }
        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
        }
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.AsNoTracking().ToListAsync();
        }
        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }
        public void Remove(T entity)
        {
            _dbSet.Remove(entity);
        }
        public void Update(T entity)
        {
            _dbSet.Update(entity);
        }
    }
}