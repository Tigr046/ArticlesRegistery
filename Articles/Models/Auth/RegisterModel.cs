using System;
using System.ComponentModel.DataAnnotations;
 
namespace Articles.Models.Auth
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "Не указан Email")]
        [EmailAddress(ErrorMessage ="Некорректный формат почты")]
        public string Email { get; set; }


        [Required(ErrorMessage = "Не указан пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Поле подтверждения пароля не заполнено")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Пароль введен неверно")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Поле день рождения обязательно для заполенния")]
        [StringLength(50,MinimumLength = 3, ErrorMessage = "Имя должна содержать от 3 до 50 символов")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Поле день рождения обязательно для заполенния")]
        [StringLength(50, MinimumLength = 3,ErrorMessage ="Фамилия должна содержать от 3 до 50 символов")]
        public string SecondName { get; set; }

        [StringLength(50)]
        public string Patronymic { get; set; }

        [Required(ErrorMessage ="Поле день рождения обязательно для заполенния")]
        [DisplayFormat(DataFormatString = "{dd/MM/yyyy}")]
        public DateTime Birthday { get; set; }
    }
}