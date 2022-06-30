using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArticleApp.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ArticleApp.Repository.Seeds
{
    public class AuthorSeeds : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.HasData(
                new Author { Id = 1, Name = "Jakob Nielsen", Email = "jakobnielsen@article.com" },
                new Author { Id = 2, Name = "Kate Moran", Email = "katemoran@article.com" },
                new Author { Id = 3, Name = "Sarah Gibbons", Email = "sarahgibbons@article.com" }
            );
        }
    }
}