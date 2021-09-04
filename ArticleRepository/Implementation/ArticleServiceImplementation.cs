using ArticleRepository.DTO;
using ArticleRepository.Model;
using ArticleRepository.Repository;
using ArticleRepository.Service;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;


namespace ArticleRepository.Implementation
{
    public class ArticleServiceImplementation : ArticleService
    {
        private readonly ArticleDbContext context;
        private readonly IMapper mapper;
        public ArticleServiceImplementation(ArticleDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public List<ArticleDTO> GetArticleByPageNumberAndPageSize(int pageNumber, int pageSize)
        {
            int skipItemCount = pageSize * pageNumber - 1 < 0 ? 0 : pageSize * pageNumber - 1;
            return mapper.Map<List<ArticleEntity>, List<ArticleDTO>>(
                context.Article.Include(zxc => zxc.Author).AsQueryable().Skip(skipItemCount).Take(pageSize).ToList());
        }

        public ArticleDTO GetArticle(int id)
        {
            ArticleEntity articleToGet = context.Article.Include(zxc => zxc.Author).FirstOrDefault(zxc => zxc.Id == id);
            if (articleToGet != null)
                return mapper.Map<ArticleEntity, ArticleDTO>(articleToGet);
            else
                throw new Exception();
        }

        public UserDTO GetAuthor(int id)
        {
            UserEntity authorToGet = context.User.FirstOrDefault(zxc => zxc.Id == id);
            if (authorToGet != null)
                return mapper.Map<UserEntity, UserDTO>(authorToGet);
            else
                throw new Exception();
        }

        public bool ArticleExists(int id) => context.Article.Any(x => x.Id == id);

        public ArticleDTO UpdateArticle(ArticleDTO articleToUpdate)
        {
            ArticleEntity updatingArticle = context.Article.FirstOrDefault(x => x.Id == articleToUpdate.Id);
            mapper.Map(articleToUpdate, updatingArticle);
            context.SaveChanges();
            return mapper.Map<ArticleEntity, ArticleDTO>(updatingArticle);
        }

        public List<CommentDTO> GetCommentsByArticleId(int articleId)
        {
            return mapper.Map<List<CommentEntity>, List<CommentDTO>>(context.Comment.Include(x => x.Author).Where(x => x.ArticleId == articleId).ToList());
        }
    }
}
