
namespace ArticleApp.Core.Models
{
    public class Author : BaseEntity, IEntity
    {
        public string Email { get; set; }
        public IEnumerable<Article> Articles { get; set; }
    }
}