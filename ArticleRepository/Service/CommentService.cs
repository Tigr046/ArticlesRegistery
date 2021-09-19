using ArticleRepository.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArticleRepository.Service
{
    public interface CommentService
    {
        List<CommentDTO> GetCommentsByArticleId(int articleId);

        CommentDTO AddComment(CommentDTO comment);
    }
}
