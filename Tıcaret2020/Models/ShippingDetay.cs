using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Tıcaret2020.Models
{
    public class ShippingDetay
    {
     
        public string UserName { get; set; }
        [Required(ErrorMessage ="Lütfen Adres giriniz...")]
        public string Adres { get; set; }

        [Required(ErrorMessage = "Lütfen Şehir giriniz...")]
        public string Sehir { get; set; }

        [Required(ErrorMessage = "Lütfen Semt giriniz...")]
        public string Semt { get; set; }

        [Required(ErrorMessage = "Lütfen Mahalle giriniz...")]
        public string Mahalle { get; set; }


        [Required(ErrorMessage = "Lütfen Posta kodu giriniz...")]
        public string PostaKodu { get; set; }
    }
}