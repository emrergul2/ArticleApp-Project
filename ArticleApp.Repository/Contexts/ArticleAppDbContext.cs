using System.Reflection;
using ArticleApp.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace ArticleApp.Repository.Contexts
{
    public class ArticleAppDbContext : DbContext
    {
        public ArticleAppDbContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}