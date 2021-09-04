using System;
using System.ComponentModel.DataAnnotations;

namespace ArticleRepository.DTO
{
    public class CommentDTO
    {
        public int Id { get; set; }

        [StringLength(220)]
        public string Text { get; set; }

        public DateTime CreationDate { get; set; }

        public UserDTO Author { get; set; }

        public int AuthorId { get; set; }

        public ArticleDTO Article { get; set; }

        public int ArticleId { get; set; }
    }
}
