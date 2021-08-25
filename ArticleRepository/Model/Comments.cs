using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ArticleRepository.Model
{
    public class Comments
    {
        public int Id { get; set; }

        [StringLength(220)]
        public string Text { get; set; }

        [ForeignKey("AuthorId")]
        public UserEntity Author { get; set; }

        public int AuthorId { get; set; }

    }
}
