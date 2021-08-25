﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ArticleRepository.Model
{
    public class AuthorEntity
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string SecondName { get; set; }

        [StringLength(50)]
        public string Patronymic { get; set; }

        [Required]
        public DateTime CreationDate { get; set; }
    }
}
