using ArticleApp.Core.DTOs;
using ArticleApp.Core.Models;

namespace ArticleApp.Core.Services
{
    public interface IArticleService : IGenericService<Article>
    {
        public Task<CustomResponseDto<List<ArticleWithAuthorAndCategoryDto>>> GetArticleWithAuthorAndCategoryAsync();
    }
}