
using ArticleApp.Core.Models;
using ArticleApp.Core.Repositories;
using ArticleApp.Repository.Contexts;
using ArticleApp.Service.Repositories;

namespace ArticleApp.Repository.Repositories
{
    public class ArticleRepository : GenericRepository<Article>, IArticleRepository
    {
        public ArticleRepository(ArticleAppDbContext dbContext) : base(dbContext)
        {
        }
    }
}