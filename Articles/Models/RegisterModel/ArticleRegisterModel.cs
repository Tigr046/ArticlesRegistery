using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Articles.Models.RegisterModel
{
    public class ArticleRegisterModel
    {
        public List<ArticleViewModel> Articles { get; set; }

        public int PageSize { get; set; }

        public int Count { get; set; }

        public int PageNumber { get; set; }
    }
}
