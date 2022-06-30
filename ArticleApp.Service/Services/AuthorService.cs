using ArticleApp.Core.Models;
using ArticleApp.Core.Repositories;
using ArticleApp.Core.Services;
using ArticleApp.Core.UnitOfWorks;

namespace ArticleApp.Service.Services
{
    public class AuthorService : GenericService<Author>, IAuthorService
    {
        public AuthorService(IGenericRepository<Author> repository, IUnitOfWork unitOfWork) : base(repository, unitOfWork)
        {
        }
    }
}