using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
namespace Tıcaret2020.Entity
{
    /*TEST VERİLERİ İÇİN DATAİNİTİALİZER SINIFI OLUŞTURDUK
     DropCreateDatabaseIfModelChanges<DataContext> MODELDE HERHANGİ BİR DEĞİŞİKLİK OLURSA
    VERİTABANINI SİLER TEKRARDAN OLUŞTURUR.*/

    public class DataInitializer:DropCreateDatabaseIfModelChanges<DataContext>
    {
        //TEST VERİLERİNİ SEED METODUNA EKLİYORUZ.
        protected override void Seed(DataContext context)
        {
            var kategoriler= new List<Category>()
              
                {

                new Category() { Name="KAMERA",Description="KAMERA ÜRÜNLERİ"},
                new Category() { Name="TELEFON",Description="TELEFON ÜRÜNLERİ"},
                new Category() { Name="BİLGİSAYAR",Description="BİLGİSAYAR ÜRÜNLERİ"}






            };


            foreach (var kategori in kategoriler)
            {
                context.Categoris.Add(kategori);
            }
            context.SaveChanges();





            var ürünler = new List<Product>()
            {
                new Product()  {Name="Canon",Description="Kamera ürünleri",Price=2500,Stock=124,IsHome=true, IsApproved=true,  IsFeatured=false,Slider=true,CategoryId=1,Image="1.jpg"},
                new Product()  {Name="Asus",Description="Bilgisayar ürünleri",Price=7000,Stock=200,IsHome=true,IsApproved=true, IsFeatured=true,Slider=true,CategoryId=3,Image ="2.jpg"},
                new Product()  {Name="Lenova",Description="Bilgisayar ürünleri",Price=5000,Stock=650,IsHome=false,IsApproved=true, IsFeatured=false,Slider=true,CategoryId=3 ,Image ="3.jpg"},
                new Product()  {Name="Samsung 6S",Description="Telefon ürünleri",Price=4500,Stock=280,IsHome=true,IsApproved=true, IsFeatured=false,Slider=true,CategoryId=2,Image = "4.jpg"},



            };

            foreach (var ürün in ürünler)
            {
                context.Products.Add(ürün);
            }
            context.SaveChanges();

            base.Seed(context);
        }


    }
}