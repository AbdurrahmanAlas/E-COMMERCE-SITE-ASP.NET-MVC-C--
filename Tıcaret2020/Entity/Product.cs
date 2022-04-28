using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tıcaret2020.Entity
{
    //ÜRÜN SINIFINI OLUŞTURUYORUZ. 
    //ÜRÜN ÖZELLİKLERİNİ YAZIYORUZ 
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public double Price { get; set; }
        public int Stock { get; set; }
        public bool Slider { get; set; }
        public bool IsHome { get; set; }
        //pOPÜLER ÜRÜNLER
        public bool IsFeatured { get; set; }
        //ONAYLI ÜRÜNLER KULLANICI GÖRÜR 
        public bool IsApproved { get; set; }
        //KATEGORİ SINIFI İLE ÜRÜN ARASINDAKİ İLİŞKİLERİ KURUYORUZ.
        public int CategoryId { get; set; }
        //HER BİR ÜRÜNÜN BİR KATEGORİSİ OLSUN İSTİYORUZ O YÜZDEN BU ŞEKİLDE YAPTIK 
        public Category Category { get; set; }

    }
}