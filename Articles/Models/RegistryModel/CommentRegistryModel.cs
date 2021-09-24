using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Articles.Models.RegistryModel
{
    public class CommentRegistryModel
    {
        public CommentRegistryModel(List<CommentViewModel> comments, int articleId)
        {
            Comments = comments;
            ArticleId = articleId;
        }
        public List<CommentViewModel> Comments { get; set; }

        public int ArticleId { get; set; }
    }
}
