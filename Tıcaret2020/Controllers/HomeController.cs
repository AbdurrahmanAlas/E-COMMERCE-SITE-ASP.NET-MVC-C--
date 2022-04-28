using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tıcaret2020.Entity;
namespace Tıcaret2020.Controllers
{
    public class HomeController : Controller
    {

        DataContext db = new DataContext();




        // 1) ANASAYFADA VE ONAYLI OLAN ÜRÜNLERİ GETİR.
        public ActionResult Index()
        {
            return View(db.Products.Where(i => i.IsHome && i.IsApproved).ToList());
            
        }






        // 2)  BÜTÜN ÜRÜNLERİ GETİRİYORUZ.
        public ActionResult Product()
        {
            return View(db.Products.ToList());
        }








        // 3)ÜRÜN LİSTESİ OLUŞTURUYORUZ. Dışardan id alınır ve Veritabanındaki CategoryId ile eşitlenir ve listelenir.
        public ActionResult ProductList(int id)
        {

            return View(db.Products.Where(i => i.CategoryId == id).ToList());

        }






         // 4) ÜRÜN DETAYI LİSTELENİR 
        public ActionResult ProductDetails(int id)
        {
            //ÜRÜN ID ile dışardan gelen id eşiTlenip  product detayı gelir 
            return View(db.Products.Where(i => i.Id == id).FirstOrDefault());


            // firstorDefault yazma sebebbim geriye donecek değerin 1 tane olduğunu göstermek için

        }






        // 5) ARAMA TUŞU 
        public ActionResult Search(string q)
        {
            // onaylı ürünleri listeliyoruz.
                   var p = db.Products.Where(i => i.IsApproved == true);


            //PARAMETRE OLARAK VERİLEN (q) STRİNG TÜRÜNDEKİ DEĞİŞKENİN BOŞ MU OLDUĞUNU KONTROL EDER.
            //EGER BOŞSA TRUE  DOLUYSA FALSE 
                    if (!string.IsNullOrEmpty(q))
                 {
                  p = p.Where(i => i.Name.Contains(q) || i.Description.Contains(q));
                //İSİM VE AÇIKLAMA  İÇERİR(q) 


                 }
                 return View(p.ToList());

           }







        // 6) SLAYTI  GETİRİYORUZ  

        //Partial view adında Create view oluştururuz . ve bu partialview i INDEX sayfasında yani
        //ana sayfada çağırıyoruz.Home/index sayfasında çağırız =>  @Html.Action("Slider","Home")

        public PartialViewResult Slider()
        {
            return PartialView(db.Products.Where(i => i.IsApproved && i.Slider).Take(9).ToList());
            //Ürünler içinden onaylı ve slider içinden 6 adet resim getiriyoruz 


        }




        // 7)ana ekrandaki ikinci slider i getiriyoruz 
        public PartialViewResult SliderKücük()
        {
            return PartialView(db.Products.Where(i => i.IsApproved && i.IsFeatured).Take(4).ToList());
            //Ürünler içinden onaylı ve slider içinden 4 adet resim getiriyoruz 


        }












        //POPÜLER ÜRÜNLERİ GETİRİYORUZ 

        //Partial view adında Create view oluştururuz . ve bu partialview i INDEX sayfasında yani
        //ana sayfada çağırıyoruz.Home/index sayfasında çağırız =>  @Html.Action("_FeaturedProuctList","Home")
        public PartialViewResult _FeaturedProductList()
        {
            return PartialView(db.Products.Where(i => i.IsApproved && i.IsFeatured).Take(6).ToList());
            //Ürünler içinden onaylı ve popüler ürünleri getirir 6 adet resim getiriyoruz ve listeliyoruz

        }









        //ADRES BİLGİLERİNİ GETİRİYORUZ

        //adres adında index oluşturup içerisinde partialviewlerden 
        //      @Html.Action("_CategoryList", "Category")
        //       @Html.Action("Summary","Cart")
        //        @Html.Action("_FeaturedProductList","Home")



        public ActionResult Adres()
        {


            return View();
        }












        // GET: Home





    }
}