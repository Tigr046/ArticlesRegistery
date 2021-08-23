using ArticleRepository.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ArticleRepository.Service
{
    public interface ArticleService
    {
        public ArticleDTO GetArticle(int id);
        public AuthorDTO GetAuthor(int id);

        public IQueryable<ArticleDTO> GetAllArticle();
    }
}
