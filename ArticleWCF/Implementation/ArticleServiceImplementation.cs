using ArticleWCF.Mapper;
using ArticleWCF.Models.DBModels;
using ArticleWCF.Models.WCFModels;
using ArticleWCF.Repository;
using ArticleWCF.Service;
using System;
using System.Linq;

namespace ArticleWCF.Implementation
{
    public class ArticleServiceImplementation : IArticleService
    {
        private readonly ArticleContext articleContext;
        private readonly Mapper.Mapper mapper;
        public ArticleServiceImplementation(ArticleContext context, Mapper.Mapper mapper)
        {
            articleContext = context;
            this.mapper = mapper;
        }
        public ArticleEntity AddArticle(ArticleTransfer articleTransfer)
        {
            if(articleContext.User.Any(x => x.Email == articleTransfer.AuthorEmail))
            {
                return articleContext.Article.Add(mapper.Map(articleTransfer));
            }
            throw new Exception($"Пользователь с Email {articleTransfer.AuthorEmail} не найден");
        }
    }
}