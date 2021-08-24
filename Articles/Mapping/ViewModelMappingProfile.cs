using ArticleRepository.DTO;
using ArticleRepository.Model;
using Articles.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Articles.Mapping
{
    public class ViewModelMappingProfile : Profile
    {
        public ViewModelMappingProfile()
        {
            CreateMap<ArticleViewModel, ArticleDTO>();
            CreateMap<ArticleDTO, ArticleViewModel>();

            CreateMap<AuthorViewModel, AuthorDTO>();
            CreateMap<AuthorDTO, AuthorViewModel>();

            CreateMap<ArticleEntity, ArticleViewModel>();
            CreateMap<ArticleViewModel, ArticleEntity>();

            CreateMap<AuthorEntity, AuthorViewModel>();
            CreateMap<AuthorViewModel, AuthorEntity>();
        }
    }
}
