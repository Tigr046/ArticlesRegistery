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

            CreateMap<UserViewModel, UserDTO>();
            CreateMap<UserDTO, UserViewModel>();
        }
    }
}
