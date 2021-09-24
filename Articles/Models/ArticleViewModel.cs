using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Articles.Models
{
    public class ArticleViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Заголовок")]
        [StringLength(350, MinimumLength =10,ErrorMessage = "Заголовок должен содержать от 10 до 350 символов")]
        [Required(ErrorMessage ="Поле заголовок обязательно для заполнения")]
        public string Title { get; set; }

        [Display(Name = "Текст статьи")]
        [Required(ErrorMessage = "Поле текст статьи обязательно для заполнения")]
        public string Text { get; set; }

        public UserViewModel Author { get; set; }

        public int AuthorId { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime? LastUpdateDate { get; set; }

        public bool CanBeUpdated { get; set; }

        public List<CommentViewModel> Comments { get; set; }

    }
}
