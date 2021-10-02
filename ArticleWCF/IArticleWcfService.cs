using ArticleWCF.Models.WCFModels;
using System.ServiceModel;


namespace ArticleWCF
{
    [ServiceContract]
    public interface IArticleWcfService
    {

        [OperationContract]
        ArticleTransfer AddArticle(ArticleTransfer article);
    }
}
