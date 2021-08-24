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

        public IQueryable<ArticleEntity> GetAllArticle()
        {
            return context.Article.Include(zxc => zxc.Author).AsQueryable();
        }

        public ArticleDTO GetArticle(int id)
        {
            ArticleEntity articleToGet = context.Article.Include(zxc => zxc.Author).FirstOrDefault(zxc => zxc.Id == id);
            if (articleToGet != null)
                return mapper.Map<ArticleEntity, ArticleDTO>(articleToGet);
            else
                throw new Exception();
        }

        public AuthorDTO GetAuthor(int id)
        {
            AuthorEntity authorToGet = context.Author.FirstOrDefault(zxc => zxc.Id == id);
            if (authorToGet != null)
                return mapper.Map<AuthorEntity, AuthorDTO>(authorToGet);
            else
                throw new Exception();
        }
    }
}
