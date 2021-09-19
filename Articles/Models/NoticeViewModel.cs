using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Articles.Models
{
    public class NoticeViewModel
    {
        public int Id { get; set; }

        public string Message { get; set; }

        public bool IsReaded { get; set; }

        public int UserId { get; set; }
        public UserViewModel User { get; set; }
    }
}
