using ArticleApp.Core.Models;
using ArticleApp.Core.Repositories;
using ArticleApp.Core.Services;
using ArticleApp.Core.UnitOfWorks;

namespace ArticleApp.Service.Services
{
    public class ArticleServiceWithNoCaching : GenericService<Article>, IArticleService
    {
        public ArticleServiceWithNoCaching(IGenericRepository<Article> repository, IUnitOfWork unitOfWork) : base(repository, unitOfWork)
        {
        }
    }
}