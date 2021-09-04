﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Articles.Models
{
    public class ArticleViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Заголовок")]
        public string Title { get; set; }

        [Display(Name = "Текст статьи")]
        public string Text { get; set; }

        public UserViewModel Author { get; set; }

        public int AuthorId { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime? LastUpdateDate { get; set; }

        public bool CanBeUpdated { get; set; }

        public List<CommentViewModel> Comments { get; set; }

    }
}
