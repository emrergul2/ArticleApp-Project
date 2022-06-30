using ArticleApp.Core.Models;
using ArticleApp.Core.Repositories;
using ArticleApp.Repository.Contexts;
using ArticleApp.Service.Repositories;

namespace ArticleApp.Repository.Repositories
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(ArticleAppDbContext dbContext) : base(dbContext)
        {

        }
    }
}