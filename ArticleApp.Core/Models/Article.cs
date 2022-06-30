
namespace ArticleApp.Core.Models
{
    public class Article : BaseEntity, IEntity
    {
        public string Summary { get; set; }
        public string ArticleText { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public int AuthorId { get; set; }
        public Author Author { get; set; }
    }
}
