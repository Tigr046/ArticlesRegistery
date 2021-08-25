﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ArticleRepository.DTO
{
    public class UserDTO
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string SecondName { get; set; }

        public string Patronymic { get; set; }

        public DateTime CreationDate { get; set; }
    }
}