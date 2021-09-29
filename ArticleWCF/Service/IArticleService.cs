using ArticleWCF.Models.DBModels;
using ArticleWCF.Models.WCFModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ArticleWCF.Service
{
    public interface IArticleService
    {
        ArticleEntity AddArticle(ArticleTransfer articleTransfer);
    }
}