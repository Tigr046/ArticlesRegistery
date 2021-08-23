using ArticleRepository.DTO;
using ArticleRepository.Model;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArticleRepository.Mapping
{
    public class ArticleMappingProfile : Profile
    {
        public ArticleMappingProfile()
        {
            CreateMap<ArticleEntity, ArticleDTO>();
            CreateMap<ArticleDTO, ArticleEntity>();

            CreateMap<AuthorEntity, AuthorDTO>();
            CreateMap<AuthorDTO, AuthorEntity>();

        }
    }
}
