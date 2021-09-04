using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Articles.Models
{
    public class CommentViewModel
    {
        public int Id { get; set; }

        public string Text { get; set; }

        public DateTime CreationDate { get; set; }

        public UserViewModel Author { get; set; }

        public int AuthorId { get; set; }

        public ArticleViewModel Article { get; set; }

        public int ArticleId { get; set; }
    }
}
