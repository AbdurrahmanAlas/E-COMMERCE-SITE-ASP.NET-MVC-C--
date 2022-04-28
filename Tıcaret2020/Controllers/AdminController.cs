using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tıcaret2020.Entity;
using Tıcaret2020.Models;

namespace Tıcaret2020.Controllers
{
    public class AdminController : Controller
    {
        DataContext db = new DataContext();
        
   
        public ActionResult Index()
        {
            StateModel model = new StateModel();
            model.BekleyenSiparisSayısı = db.Orders.Where(i => i.OrderState == OrderState.Bekleniyor).ToList().Count();
            model.TamamlananSiparisSayısı = db.Orders.Where(i => i.OrderState == OrderState.Tamamlandı).ToList().Count();
            model.PaketlenenSiparisSayısı = db.Orders.Where(i => i.OrderState == OrderState.Paketlendi).ToList().Count();
            model.KargolananSiparisSayısı = db.Orders.Where(i => i.OrderState == OrderState.Kargolandı).ToList().Count();
            model.UrunSayısı = db.Products.Count();
            model.SiparisSayısı = db.Orders.Count();

            return View(model);
        }

        public PartialViewResult BildirimMenusu()
        {
            var bildirim = db.Orders.Where(i => i.OrderState == OrderState.Bekleniyor).ToList();
            return PartialView(bildirim);



        }


    }
}