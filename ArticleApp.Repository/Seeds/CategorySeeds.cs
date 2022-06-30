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
                new Category
                {
                    Id = 1,
                    Name = "Content Strategy",
                    Description = "A content strategy is an all-encompassing approach for creating content that drives key business objectives"
                },
                new Category
                {
                    Id = 2,
                    Name = "Ecommerce",
                    Description = "E-commerce (electronic commerce) is the buying and selling of goods and services, or the transmitting of funds or data, over an electronic network, primarily the internet."
                },
                new Category
                {
                    Id = 3,
                    Name = "Design Process",
                    Description = "The Design Process is an approach for breaking down a large project into manageable chunks. Architects, engineers, scientists, and other thinkers use the design process to solve a variety of problems."
                },
                new Category
                {
                    Id = 4,
                    Name = "Agile",
                    Description = "agile is a group of methodologies that demonstrate a commitment to tight feedback cycles and continuous improvement."
                }
            );
        }
    }
}