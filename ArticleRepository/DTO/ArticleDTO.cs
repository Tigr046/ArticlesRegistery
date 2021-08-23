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

        public AuthorDTO Author { get; set; }
    }
}
