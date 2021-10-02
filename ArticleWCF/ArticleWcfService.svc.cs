

using ArticleWCF.Models.WCFModels;
using ArticleWCF.Service;
using System.Security.Principal;

namespace ArticleWCF
{
    public class ArticleWcfService : IArticleWcfService
    {
        private readonly IArticleService articleService;
        private readonly Mapper.Mapper mapper;
        public ArticleWcfService(IArticleService articleService, Mapper.Mapper mapper)
        {
            this.mapper = mapper;
            this.articleService = articleService;
        }

        public ArticleTransfer AddArticle(ArticleTransfer article)
        {
            return mapper.Map(articleService.AddArticle(article));
        }
    }
}
