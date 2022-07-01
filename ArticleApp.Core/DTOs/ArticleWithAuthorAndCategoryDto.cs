
namespace ArticleApp.Core.DTOs
{
    public class ArticleWithAuthorAndCategoryDto : ArticleDto
    {
        public AuthorDto Author { get; set; }
        public CategoryDto Category { get; set; }
    }
}