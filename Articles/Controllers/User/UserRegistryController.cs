using ArticleRepository.DTO;
using ArticleRepository.Service;
using Articles.Models;
using Articles.Models.RegistryModel;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Articles.Controllers.User
{
    public class UserRegistryController : Controller
    {
        private readonly UserService userService;
        private readonly IMapper mapper;
        public UserRegistryController(UserService userService, IMapper mapper)
        {
            this.mapper = mapper;
            this.userService = userService;
        }
        [CustomAttribute.CustomAuthorization("admin")]
        public IActionResult Index()
        {
            return View(new UserRegistryModel() { 
                UserViews = mapper.Map<List<UserDTO>, List<UserViewModel>>(userService.GetAllUsersByPageNumberAndPageSize(100,0))});
        }
    }
}
