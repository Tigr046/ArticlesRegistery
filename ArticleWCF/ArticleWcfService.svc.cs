

using ArticleWCF.Models.WCFModels;
using ArticleWCF.Service;

namespace ArticleWCF
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени класса "ArticleWcfService" в коде, SVC-файле и файле конфигурации.
    // ПРИМЕЧАНИЕ. Чтобы запустить клиент проверки WCF для тестирования службы, выберите элементы ArticleWcfService.svc или ArticleWcfService.svc.cs в обозревателе решений и начните отладку.
    public class ArticleWcfService : IArticleWcfService
    {
        private readonly IArticleService articleService;
        public ArticleWcfService(IArticleService articleService)
        {
            this.articleService = articleService;
        }

        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        

        public ArticleTransfer GetArticle(ArticleTransfer article)
        {
            articleService.AddArticle(article);
            return new ArticleTransfer() { Text = article.Text };
        }
    }
}
