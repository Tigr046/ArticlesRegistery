using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ArticleWCF.Models.DBModels
{
    public class UserEntity
    {
        public int Id { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string FirstName { get; set; }

        public string SecondName { get; set; }

        public string Patronymic { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime Birthday { get; set; }

        public int RoleId { get; set; }

        public virtual List<ArticleEntity> Articles { get; set; }

    }
}