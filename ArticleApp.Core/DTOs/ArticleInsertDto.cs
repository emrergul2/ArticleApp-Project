using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArticleApp.Core.DTOs
{
    public class ArticleInsertDto : IDto
    {
        public string Name { get; set; }
        public string Summary { get; set; }
        public string ArticleText { get; set; }
        public int CategoryId { get; set; }
        public int AuthorId { get; set; }
    }
}