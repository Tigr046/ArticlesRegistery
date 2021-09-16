using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Articles.Controllers.Notice
{
    public class NoticeController : Controller
    {
        public IActionResult GetUnreadedNoticeCount()
        {
            return new JsonResult(1);
        }
    }
}
