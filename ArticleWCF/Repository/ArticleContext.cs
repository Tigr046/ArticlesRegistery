using ArticleWCF.Models.DBModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ArticleWCF.Repository
{
    public class ArticleContext : DbContext
    {
        public ArticleContext(string connectionString):base(connectionString)
        {

        }
        public DbSet<ArticleEntity> Article { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ArticleEntity>().ToTable("Article","dbo");
        }
    }
}