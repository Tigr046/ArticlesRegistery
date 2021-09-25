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
            new HeaderLinkModel(){FormId = "AllUserLink", Controller = "UserRegistry",Action = "Index", Text = "Пользователи", Roles = new List<string>(){"admin"} }

        };

        private readonly UserService userService;
        public LayoutController(UserService userService)
        {
            this.userService = userService;
        }

        public IActionResult GetHeaderByUser()
        {
            int? userid = GetUserIdByCurrContext();
            List<HeaderLinkModel> allowedLinks = new List<HeaderLinkModel>();
            if (userid.HasValue)
            {
                RoleDTO userRole = userService.GetUserRoleByUserId(userid.Value);
                foreach(HeaderLinkModel headerLink in allHeaderLinks)
                {
                    if (headerLink.Roles.Contains(userRole.Name))
                        allowedLinks.Add(headerLink);
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
        private int? GetUserIdByCurrContext()
        {
            int userId = 0;
            if (Int32.TryParse(User.FindFirst((x) => x.Type == "Id")?.Value, out userId))
            {
                return userId;
            }
            return null;
        }
    }
}
