using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tıcaret2020.Entity;
using Tıcaret2020.Models;

namespace Tıcaret2020.Controllers
{
    public class CartController : Controller
    {
        DataContext db = new DataContext();
        // GET: Cart
        public ActionResult Index()
        {
            return View(GetCart());
        }





        //SEPETE ÜRÜN EKLİYORUZ DIŞARDAN ÜRÜN ALIYORUZ İD ALIRIZ.
         public ActionResult AddToCart(int Id)
        {
            var product = db.Products.FirstOrDefault(i => i.Id == Id);

            //ÜRÜN VERİTABANINDAYSA 
            if (product != null)

            {

                GetCart().AddProduct(product, 1);


            }


            return RedirectToAction("Index");

        }




        //KULLANICIYA DAHA ÖNCE KART VERDİYSEM ESKİ KARTI GETİRİP VERİYORUM 
        public Cart GetCart()
        {

            var cart = (Cart)Session["Cart"];
            if (cart == null)
            {


                cart = new Cart();
                Session["Cart"] = cart;

            }


            return cart;


        }









        public ActionResult Checkout()
        {
            return View(new ShippingDetay());



        }
        [HttpPost]
        public ActionResult Checkout(ShippingDetay model)
        {
            var cart = GetCart();
            if(cart.Cartlines.Count==0)
            {
                ModelState.AddModelError("ÜrünYok", "Sepetinizde ürün bulunmamaktadır...");


            }
            if(ModelState.IsValid)
            {
                SaveOrder(cart, model);
          

                cart.Clear();

                return View("SiparişTamamlandı");


            }
            else
            {
                return View(model);



            }


       



        }

        private void SaveOrder(Cart cart,ShippingDetay model)
        {

            var order = new Order();
            order.OrderNumber = "A" + (new Random()).Next(1111, 9999).ToString();
            order.Total = cart.Total();
            order.OrderDate = DateTime.Now;
            order.UserName = User.Identity.Name;
            order.OrderState = OrderState.Bekleniyor;
            order.Adres = model.Adres;
            order.Sehir = model.Sehir;
            order.Sehir = model.Semt;
            order.Mahalle = model.Mahalle;
            order.PostaKodu = model.PostaKodu;
            order.Orderlines = new List<Orderline>();

            foreach(var item in cart.Cartlines)
            {
                var orderline = new Orderline();
                orderline.Quantity = item.Quantity;
                orderline.Price = item.Quantity * item.Product.Price;
                orderline.ProductId = item.Product.Id;
                order.Orderlines.Add(orderline);

                    


            }
            db.Orders.Add(order);
            db.SaveChanges();

        }

        public PartialViewResult Summary()
        {

            return PartialView(GetCart());


        }

        public PartialViewResult Summary1()
        {

            return PartialView(GetCart());


        }



        public ActionResult RemoveFromCart(int Id)
        {


            var product = db.Products.FirstOrDefault(i => i.Id == Id);
            if(product!=null)
            {


                GetCart().DeleteProduct(product);




            }
            return RedirectToAction("Index");



        }




     

       



    }
}