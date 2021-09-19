using ArticleRepository.DTO;
using ArticleRepository.Model;
using ArticleRepository.Repository;
using ArticleRepository.Service;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace ArticleRepository.Implementation
{
    public class CommentServiceImplementation : CommentService
    {
        private readonly ArticleDbContext context;
        private readonly IMapper mapper;
        public CommentServiceImplementation(ArticleDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public CommentDTO AddComment(CommentDTO comment)
        {
            return mapper.Map<CommentEntity,CommentDTO>(context.Add(mapper.Map<CommentDTO, CommentEntity>(comment)).Entity);
        }

        public List<CommentDTO> GetCommentsByArticleId(int articleId)
        {
            return mapper.Map<List<CommentEntity>, List<CommentDTO>>(context.Comment.Include(x => x.Author).Where(x => x.ArticleId == articleId).ToList());
        }
    }
}
