using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ArticleRepository.Model
{
    public class CommentEntity
    {
        public int Id { get; set; }

        [StringLength(220)]
        public string Text { get; set; }

        public DateTime CreationDate { get; set; }

        [ForeignKey("AuthorId")]
        public UserEntity Author { get; set; }

        public int AuthorId { get; set; }

        [ForeignKey("ArticleId")]
        public ArticleEntity Article { get; set; }
        
        public int ArticleId { get; set; }

    }
}
