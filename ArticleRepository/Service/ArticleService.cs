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
        ArticleDTO GetArticle(int id);

        UserDTO GetAuthorByArticleId(int articleId);
        UserDTO GetAuthor(int id);

        List<ArticleDTO> GetArticleByPageNumberAndPageSize(int pageNumber, int pageSize);

        bool ArticleExists(int id);

        ArticleDTO UpdateArticle(ArticleDTO articleToUpdate);

        ArticleDTO AddArticle(ArticleDTO articleToUpdate);

    }
}
