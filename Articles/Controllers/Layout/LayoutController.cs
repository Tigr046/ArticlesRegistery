using ArticleRepository.DTO;
using ArticleRepository.Service;
using Articles.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Articles.Controllers.Layout
{
    public class LayoutController : Controller
    {
        private readonly List<HeaderLinkModel> allHeaderLinks = new List<HeaderLinkModel>()
        {
            new HeaderLinkModel(){FormId = "MainPageLink", Controller = "Home",Action = "Index", Text = "Главная страница", Roles = new List<string>(){"admin", "user", "anon" } },
            new HeaderLinkModel(){FormId = "ArticleRegistryLink", Controller = "ArticleRegistry",Action = "Index", Text = "Статьи", Roles = new List<string>(){"admin", "user", "anon" } },
            new HeaderLinkModel(){FormId = "NoticeLink", Controller = "Notice",Action = "GetAllUserNotices", Text = "Уведомления", Roles = new List<string>(){"admin", "user" } },
            new HeaderLinkModel(){FormId = "AllUserLink", Controller = "UserRegistry",Action = "Index", Text = "Пользователи", Roles = new List<string>(){"admin"} },
            new HeaderLinkModel(){FormId = "LoginUser", Controller = "Account",Action = "Login", Text = "Войти", Roles = new List<string>(){"anon"} },
            new HeaderLinkModel(){FormId = "UserName", Controller = "",Action = "", Text = "Имя пользователя", Roles = new List<string>(){"user","admin"} },
            new HeaderLinkModel(){FormId = "LogOut", Controller = "Account",Action = "Logout", Text = "Выйти", Roles = new List<string>(){"user","admin"} },


        };

        private readonly UserService userService;
        public LayoutController(UserService userService)
        {
            this.userService = userService;
        }

        public IActionResult GetHeaderByUser()
        {
            int? userid = userService.GetUserIdByCurrContext(User);
            List<HeaderLinkModel> allowedLinks = new List<HeaderLinkModel>();
            if (userid.HasValue)
            {
                UserDTO user = userService.GetUser(userid.Value);
                foreach(HeaderLinkModel headerLink in allHeaderLinks)
                {
                    if (headerLink.Roles.Contains(user.Role.Name))
                    {
                        if (headerLink.FormId == "UserName")
                            headerLink.Text = $"{user.SecondName} {user.FirstName}";
                        allowedLinks.Add(headerLink);
                    }
                }

            }
            else
            {
                foreach (HeaderLinkModel headerLink in allHeaderLinks)
                {
                    if (headerLink.Roles.Contains("anon"))
                        allowedLinks.Add(headerLink);
                }
            }

            return View("_HeaderLinkContent", allowedLinks);
        }
    }
}
