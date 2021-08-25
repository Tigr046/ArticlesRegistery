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
            CreateMap<ArticleDTO, ArticleEntity>().ForMember(x => x.LastUpdateDate, opt => opt.MapFrom(src => DateTime.Now));

            CreateMap<UserEntity, UserDTO>();
            CreateMap<UserDTO, UserEntity>();

        }
    }
}
