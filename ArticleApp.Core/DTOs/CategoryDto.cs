using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArticleApp.Core.DTOs
{
    public class CategoryDto:BaseDto,IDto
    {
        public string Description { get; set; }
    }
}