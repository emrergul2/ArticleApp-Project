
using ArticleApp.Core.Models;
using ArticleApp.Core.Repositories;
using ArticleApp.Repository.Contexts;
using ArticleApp.Service.Repositories;

namespace ArticleApp.Repository.Repositories.Contexts
{
    public class AuthorRepository : GenericRepository<Author>, IAuthorRepository
    {
        public AuthorRepository(ArticleAppDbContext dbContext) : base(dbContext)
        {
        }
    }
}