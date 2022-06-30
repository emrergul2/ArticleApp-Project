using ArticleApp.Core.Models;
using ArticleApp.Core.Repositories;
using ArticleApp.Core.Services;
using ArticleApp.Core.UnitOfWorks;

namespace ArticleApp.Service.Services
{
    public class CategoryService : GenericService<Category>, ICategoryService
    {
        public CategoryService(IGenericRepository<Category> repository, IUnitOfWork unitOfWork) : base(repository, unitOfWork)
        {
        }
    }
}