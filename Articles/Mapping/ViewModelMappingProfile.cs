using ArticleRepository.DTO;
using Articles.Models;
using Articles.Models.Auth;
using AutoMapper;
using System;

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

            CreateMap<CommentViewModel, CommentDTO>();
            CreateMap<CommentDTO, CommentViewModel>();

            CreateMap<UserDTO, RegisterModel>();
            CreateMap<RegisterModel, UserDTO>().AfterMap((r,u) => u.CreationDate = DateTime.Now);

            CreateMap<NoticeViewModel, NoticeDTO>();
            CreateMap<NoticeDTO, NoticeViewModel>();
        }
    }
}
