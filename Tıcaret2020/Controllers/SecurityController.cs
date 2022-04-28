using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Tıcaret2020.Entity;
using Tıcaret2020.Models;

namespace Tıcaret2020.Controllers
{
    public class SecurityController : Controller
    {
        // GET: Security
        DataContext db = new DataContext();
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Kullanıcı kullanici)
        {
            var kullanıcı = db.Kullanıcıs.FirstOrDefault(x => x.vatEmail == kullanici.vatEmail && x.vatParola == kullanici.vatParola);


            if (kullanıcı!=null)
            {

                FormsAuthentication.SetAuthCookie(kullanıcı.vatEmail, false);


                return RedirectToAction("Index","Home");



            }
            else
            {
                ViewBag.mesaj = "Geçersiz kullanıcı adı veya şifre girdiniz...";
                return View();
            }



          
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
        [HttpGet]
        public PartialViewResult partial1()
        {

            return PartialView();

        }
        [HttpPost]
        public PartialViewResult partial1(Kullanıcı p)
        {
            db.Kullanıcıs.Add(p);
            db.SaveChanges();
            return PartialView("Login");


        }
        public ActionResult Index()
        {

            var username = User.Identity.Name;
            var orders = db.Orders.Where(i => i.UserName == username).Select(i => new UserOrder
            {
                Id = i.Id,
                OrderNumber = i.OrderNumber,
                OrderState = i.OrderState,
                OrderDate = i.OrderDate,
                Total = i.Total
            }).OrderByDescending(i => i.OrderDate).ToList();




            return View(orders);
        }

        public ActionResult Details(int Id)
        {

            var model = db.Orders.Where(i => i.Id == Id).Select(i => new OrderDetails()
            {
                OrderId = i.Id,
                OrderNumber = i.OrderNumber,
                Total = i.Total,
                OrderDate = i.OrderDate,
                OrderState = i.OrderState,
                Adres = i.Adres,
                Sehir = i.Sehir,
                Semt = i.Semt,
                Mahalle = i.Mahalle,
                PostaKodu = i.PostaKodu,
                OrderLines = i.Orderlines.Select(x => new OrderLineModel()
                {
                    ProductId = x.ProductId,
                    Image = x.Product.Image,

                    ProductName = x.Product.Name,
                    Quantity = x.Quantity,
                    Price = x.Price




                }).ToList()



            }).FirstOrDefault();


            return View(model);
        }
    }
}


