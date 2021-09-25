using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Articles.Models
{
    public class HeaderLinkModel
    {
        public string FormId { get; set; }

        public string Action { get; set; }

        public string Controller { get; set; }

        public string Text { get; set; }

        public List<string> Roles { get; set; }
    }
}
