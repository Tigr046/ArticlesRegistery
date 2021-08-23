using ArticleRepository.Model;
using Microsoft.EntityFrameworkCore;

namespace ArticleRepository.Repository
{
    public class ArticleDbContext : DbContext
    {
        public DbSet<ArticleEntity> Article { get; set; }
        public DbSet<AuthorEntity> Author { get; set; }


        public ArticleDbContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.\\sqlexpress;Database=Article;Trusted_Connection=True;");
        }
    }
}
