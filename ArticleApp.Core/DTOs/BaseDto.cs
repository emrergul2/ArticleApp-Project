using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArticleApp.Core.DTOs
{
    public abstract class BaseDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}