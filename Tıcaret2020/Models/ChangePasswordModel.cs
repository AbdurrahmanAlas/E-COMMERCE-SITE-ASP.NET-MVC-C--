using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Tıcaret2020.Models
{
    public class ChangePasswordModel
    {
        [Required]
        [DisplayName("Eski Şifre")]
        public string OldPassword { get; set; }
        [Required]
        [DisplayName("Yeni Şifre")]
        [StringLength(100,MinimumLength =5,ErrorMessage ="Şifreniz en az 5 karakter olmalıdır..")]
        public string NewPassword { get; set; }
        [Required]
        [DisplayName(" Şifre Tekrar")]
        [Compare("NewPassword",ErrorMessage ="şifreler aynı değil")]
        public string ConNewPassword { get; set; }






    }
}