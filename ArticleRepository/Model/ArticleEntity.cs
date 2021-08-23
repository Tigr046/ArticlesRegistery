using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ArticleRepository.Model
{
    public class ArticleEntity
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Text { get; set; }

        [ForeignKey("AuthorId")]
        public AuthorEntity Author { get; set; }
        public int AuthorId { get; set; }

    }
}
