using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ArticleRepository.Model
{
    public class ArticleEntity
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Text { get; set; }

        [ForeignKey("AuthorId")]
        public UserEntity Author { get; set; }

        [Required]
        public int AuthorId { get; set; }

        [Required]
        public DateTime CreationDate { get; set; }

        public DateTime? LastUpdateDate { get; set; }

        public virtual List<CommentEntity> Comments { get; set; }

    }
}
