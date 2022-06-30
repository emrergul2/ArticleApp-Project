
namespace ArticleApp.Core.Models
{
    public class Category : BaseEntity, IEntity
    {
        public string Description { get; set; }
        public IEnumerable<Article> Articles { get; set; }
    }
}