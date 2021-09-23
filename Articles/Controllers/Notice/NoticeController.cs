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
            return View("NoticeRegistry", mapper.Map<List<NoticeDTO>,List<NoticeViewModel>>(noticeService.GetAllNoticesByUser(GetUserIdByCurrContext()).OrderByDescending(x => x.Id).ToList()));
        }

        public IActionResult GetUnreadedNoticeCount()
        {
            return new JsonResult(noticeService.GetUnreadedNoticeCountByUserId(GetUserIdByCurrContext()));
        }

        public IActionResult MarkNoticeAsRead(int noticeId)
        {
            noticeService.MarkNoticeAsRead(noticeId);
            return new JsonResult(true);
        }
        private int GetUserIdByCurrContext()
        {
            int userId = 0;
            if (Int32.TryParse(User.FindFirst((x) => x.Type == "Id")?.Value, out userId))
            {
                return userId;
            }
            throw new Exception("Значение id получение из куки неполучилось сконвертировать в int");
        }
    }
}
