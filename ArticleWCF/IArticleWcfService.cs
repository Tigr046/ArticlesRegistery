using ArticleWCF.Models.WCFModels;
using System.ServiceModel;


namespace ArticleWCF
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени интерфейса "IArticleWcfService" в коде и файле конфигурации.
    [ServiceContract]
    public interface IArticleWcfService
    {

        [OperationContract]
        string GetData(int value);

        [OperationContract]
        ArticleTransfer GetArticle(ArticleTransfer article);
    }
}
