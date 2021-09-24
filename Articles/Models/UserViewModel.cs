using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Articles.Models
{
    public class UserViewModel
    {
        public int Id { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string FirstName { get; set; }

        public string SecondName { get; set; }

        public string Patronymic { get; set; }
        
        public DateTime CreationDate { get; set; }

        public DateTime Birthday { get; set; }

        public List<CommentViewModel> Comments { get; set; }

        public string UserName => $"{SecondName} {FirstName[0]}.{Patronymic[0]}.";
    }
}
