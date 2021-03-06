using System;
using System.Collections.Generic;
using System.Text;

namespace ArticleRepository.DTO
{
    public class ArticleDTO
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Text { get; set; }

        public UserDTO Author { get; set; }

        public int AuthorId { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime? LastUpdateDate { get; set; }


        public List<CommentDTO> Comments { get; set; }
    }
}
