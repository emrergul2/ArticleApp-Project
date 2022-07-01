
using ArticleApp.Core.Models;
using ArticleApp.Core.Repositories;
using ArticleApp.Repository.Contexts;
using ArticleApp.Service.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ArticleApp.Repository.Repositories
{
    public class ArticleRepository : GenericRepository<Article>, IArticleRepository
    {
        public ArticleRepository(ArticleAppDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<List<Article>> GetArticleWithAuthorAndCategoryAsync()
        {
            return await _dbContext.Articles.Include(x => x.Category)
                                 .Include(x => x.Author).ToListAsync();
        }
    }
}