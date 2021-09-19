using System.Collections.Generic;

namespace Articles.Models.RegistryModel
{
    public class ArticleRegistryModel
    {
        public List<ArticleViewModel> Articles { get; set; }

        public int PageSize { get; set; }

        public int Count { get; set; }

        public int PageNumber { get; set; }
    }
}
