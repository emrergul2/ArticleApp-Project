using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArticleApp.Core.DTOs
{
    public class ArticleDto : BaseDto, IDto
    {
        public string Summary { get; set; }
        public string ArticleText { get; set; }
    }
}
