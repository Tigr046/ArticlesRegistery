using ArticleRepository.Model;
using Microsoft.EntityFrameworkCore;

namespace ArticleRepository.Repository
{
    public class ArticleDbContext : DbContext
    {
        public DbSet<ArticleEntity> Article { get; set; }
        public DbSet<UserEntity> User { get; set; }
        public DbSet<CommentEntity> Comment { get; set; }
        public DbSet<NoticeEntity> Notice { get; set; }
        public DbSet<RoleEntity> Role { get; set; }



        public ArticleDbContext(DbContextOptions<ArticleDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();   // создаем базу данных при первом обращении
        }
    }
}
