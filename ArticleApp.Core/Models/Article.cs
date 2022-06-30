
namespace ArticleApp.Core.Models
{
    public class Article : BaseEntity, IEntity
    {
        public string Title { get; set; }
        public string Summary { get; set; }
        public string ArticleText { get; set; }
        public Category Category { get; set; }
        public Author Author { get; set; }
    }
}