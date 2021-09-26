using ArticleRepository.DTO;
using ArticleRepository.Service;
using Articles.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Articles.Controllers.Notice
{
    public class NoticeController : Controller
    {
        private readonly NoticeService noticeService;
        private readonly UserService userService;
        private readonly IMapper mapper;

        public NoticeController(NoticeService noticeService, IMapper mapper, UserService userService)
        {
            this.mapper = mapper;
            this.noticeService = noticeService;
            this.userService = userService;
        }

        public IActionResult GetAllUserNotices()
        {
            int? userId = userService.GetUserIdByCurrContext(User);
            if (userId.HasValue)
                return View("NoticeRegistry", mapper.Map<List<NoticeDTO>,List<NoticeViewModel>>(noticeService.GetAllNoticesByUser(userId.Value).OrderByDescending(x => x.Id).ToList()));
            return View("NoticeRegistry", new List<NoticeViewModel>());
        }

        public IActionResult GetUnreadedNoticeCount()
        {
            int? userId = userService.GetUserIdByCurrContext(User);
            if (userId.HasValue)
                return new JsonResult(noticeService.GetUnreadedNoticeCountByUserId(userId.Value));
            return new JsonResult(0);
        }

        public IActionResult MarkNoticeAsRead(int noticeId)
        {
            noticeService.MarkNoticeAsRead(noticeId);
            return new JsonResult(true);
        }

        public IActionResult Delete(int id)
        {
            noticeService.DeleteNotice(id);
            return RedirectToAction("GetAllUserNotices");
        }
    }
}
