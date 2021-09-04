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
        public UserDTO GetAuthor(int id);

        public List<ArticleDTO> GetArticleByPageNumberAndPageSize(int pageNumber, int pageSize);

        public bool ArticleExists(int id);

        public ArticleDTO UpdateArticle(ArticleDTO articleToUpdate);
        public List<CommentDTO> GetCommentsByArticleId(int articleId);

    }
}
