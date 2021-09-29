using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ArticleWCF.Models.DBModels
{
    public class ArticleEntity
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Text { get; set; }

        [Required]
        public int AuthorId { get; set; }

        [Required]
        public DateTime CreationDate { get; set; }

        public DateTime? LastUpdateDate { get; set; }

    }
}