using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArticleApp.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ArticleApp.Repository.Seeds
{
    public class CategorySeeds : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(
                new Category { Id = 1, Name = "Content Strategy" },
                new Category { Id = 2, Name = "Ecommerce" },
                new Category { Id = 3, Name = "Design Process" },
                new Category { Id = 4, Name = "Agile" }
            );
        }
    }
}