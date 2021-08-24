using ArticleRepository.DTO;
using ArticleRepository.Model;
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

        public List<ArticleDTO> GetArticleByPageNumberAndPageSize(int pageNumber, int pageSize);
    }
}
