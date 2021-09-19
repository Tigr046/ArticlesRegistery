using System;
using System.Collections.Generic;
using System.Text;

namespace ArticleRepository.DTO
{
    public class UserDTO
    {
        public int Id { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string FirstName { get; set; }

        public string SecondName { get; set; }

        public string Patronymic { get; set; }

        public DateTime CreationDate { get; set; }

        public List<CommentDTO> Comments { get; set; }

    }
}
