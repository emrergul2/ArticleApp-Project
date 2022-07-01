using ArticleApp.Core.Models;

namespace ArticleApp.Core.Repositories
{
    public interface IArticleRepository : IGenericRepository<Article>
    {
        public Task<List<Article>> GetArticleWithAuthorAndCategoryAsync();
    }
}