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
        NoticeService noticeService;
        private readonly IMapper mapper;

        public NoticeController(NoticeService noticeService, IMapper mapper)
        {
            this.mapper = mapper;
            this.noticeService = noticeService;
        }

        public IActionResult GetAllUserNotices()
        {
            int? userId = GetUserIdByCurrContext();
            if (userId.HasValue)
                return View("NoticeRegistry", mapper.Map<List<NoticeDTO>,List<NoticeViewModel>>(noticeService.GetAllNoticesByUser(userId.Value).OrderByDescending(x => x.Id).ToList()));
            return View("NoticeRegistry", new List<NoticeViewModel>());
        }

        public IActionResult GetUnreadedNoticeCount()
        {
            int? userId = GetUserIdByCurrContext();
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
