using ArticleRepository.DTO;
using ArticleRepository.Service;
using Articles.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Articles.Controllers.User
{
    public class UserController : Controller
    {
        private readonly UserService userService;
        private readonly IMapper mapper;
        public UserController(UserService userService, IMapper mapper)
        {
            this.userService = userService;
            this.mapper = mapper;
        }
        public IActionResult Edit(int id)
        {
            return View(mapper.Map<UserDTO,UserViewModel>(userService.GetUser(id)));
        }

        [HttpPost]
        [CustomAttribute.CustomAuthorization(Roles:"admin,user")]
        public IActionResult Edit(UserViewModel user)
        {
            int? userId = userService.GetUserIdByCurrContext(User);
            if(userId.HasValue && (userId.Value == user.Id || User.IsInRole("admin")))
            {
                UserDTO updatedUser = userService.UpdateUser(mapper.Map<UserViewModel, UserDTO>(user));
                return RedirectToAction("Edit", updatedUser.Id);
            }
            throw new Exception("У вас нет права для редатирования пользователя");
        }
    }
}
