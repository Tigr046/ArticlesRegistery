﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Articles.Models
{
    public class ArticleViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Text { get; set; }

        public AuthorViewModel Author { get; set; }
        public DateTime CreationDate { get; set; }
        public string AuthorName => $"{Author.SecondName} {Author.FirstName[0]}.{Author.Patronymic[0]}.";

        public bool CanBeUpdated { get; set; }
    }
}
