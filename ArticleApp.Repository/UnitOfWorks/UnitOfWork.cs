using ArticleApp.Core.UnitOfWorks;
using ArticleApp.Repository.Contexts;

namespace ArticleApp.Repository.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ArticleAppDbContext _dbContext;

        public UnitOfWork(ArticleAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Commit()
        {
            _dbContext.SaveChanges();
        }
        public async Task CommitAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}