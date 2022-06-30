using ArticleApp.Core.Models;
using ArticleApp.Core.Repositories;
using ArticleApp.Core.Services;
using ArticleApp.Core.UnitOfWorks;

namespace ArticleApp.Service.Services
{
    public class ArticleService : GenericService<Article>, IArticleService
    {
        public ArticleService(IGenericRepository<Article> repository, IUnitOfWork unitOfWork) : base(repository, unitOfWork)
        {
        }
    }
}