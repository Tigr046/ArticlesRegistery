using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ArticleRepository.Model
{
    public class UserEntity
    {
        public int Id { get; set; }

        [Required]
        [StringLength(64)]
        public string Email { get; set; }

        [Required]
        [StringLength(64)]
        public string Password { get; set; }

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

        [Required]
        public DateTime Birthday { get; set; }

        public virtual List<CommentEntity> Comments { get; set; }

        public virtual List<NoticeEntity> Notices { get; set; }
    }
}
