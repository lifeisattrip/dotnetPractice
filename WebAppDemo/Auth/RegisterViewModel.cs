using System;
using System.ComponentModel.DataAnnotations;

namespace WebApiDemo.Auth
{
    public class RegisterViewModel
    {
        [Required] public string UserName { get; set; }

        [Required(ErrorMessage = "密码不能为空")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required] public string FullName { get; set; }
        [Required] [DataType(DataType.Date)] public DateTime BirthDate { get; set; }
    }
}
