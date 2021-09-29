using ArticleWCF.Models.DBModels;
using ArticleWCF.Models.WCFModels;
using ArticleWCF.Repository;
using ArticleWCF.Service;

namespace ArticleWCF.Implementation
{
    public class ArticleServiceImplementation : IArticleService
    {
        private readonly ArticleContext articleContext;
        public ArticleServiceImplementation(ArticleContext context)
        {
            articleContext = context;
        }
        public ArticleEntity AddArticle(ArticleTransfer articleTransfer)
        {
            throw new System.NotImplementedException();
        }
    }
}