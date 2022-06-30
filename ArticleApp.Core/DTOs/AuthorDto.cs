using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArticleApp.Core.DTOs
{
    public class AuthorDto : BaseDto, IDto
    {
        public string Email { get; set; }
    }
}