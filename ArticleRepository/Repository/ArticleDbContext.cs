using ArticleRepository.Model;
using Microsoft.EntityFrameworkCore;

namespace ArticleRepository.Repository
{
    public class ArticleDbContext : DbContext
    {
        public DbSet<ArticleEntity> Article { get; set; }
        public DbSet<AuthorEntity> Author { get; set; }

        public ArticleDbContext(DbContextOptions<ArticleDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();   // создаем базу данных при первом обращении
        }
    }
}
