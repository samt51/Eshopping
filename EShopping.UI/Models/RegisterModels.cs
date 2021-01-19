using System;
using System.ComponentModel.DataAnnotations;

namespace EShopping.UI.Models
{
    public class RegisterModels
    {
        [Required(ErrorMessage ="Ad ve Soyadınızı Giriniz")]
        public string FullName { get; set; }
        [Required(ErrorMessage ="Kullanıcı Adı Girmeniz Gerekiyor")]
        public string UserName { get; set; }
        [Required( ErrorMessage ="Kurallar içinde şifre belirtiniz")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required(ErrorMessage ="Şifrenizi Tekrarlayınız")]
        [DataType(DataType.Password)]
        [Compare("Password",ErrorMessage ="Şifreniz Uyuşmuyor")]
        public string RePassword { get; set; }

        [Required(ErrorMessage ="Mail Adresinizi Belirtiniz")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
}
