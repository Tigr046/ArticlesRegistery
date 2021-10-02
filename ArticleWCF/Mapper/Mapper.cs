using ArticleWCF.Models.DBModels;
using ArticleWCF.Models.WCFModels;
using ArticleWCF.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ArticleWCF.Mapper
{
    public class Mapper
    {
        private ArticleContext articleContext;
        public Mapper(ArticleContext articleContext)
        {
            this.articleContext = articleContext;
        }
        public ArticleEntity Map(ArticleTransfer model)
        {
            return new ArticleEntity() { 
                Title = model.Title,
                Text = model.Text,
                CreationDate = DateTime.Now,
                LastUpdateDate = DateTime.Now,
                AuthorId = articleContext.User.First(x => x.Email == model.AuthorEmail).Id
            };
        }

        public ArticleTransfer Map(ArticleEntity model)
        {
            return new ArticleTransfer()
            {
                Title = model.Title,
                Text = model.Text,
                AuthorEmail = articleContext.User.First(x => x.Id == model.AuthorId).Email
            };
        }
    }
}