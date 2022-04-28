using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tıcaret2020.Entity
{
    public class Order
    {
        public int Id { get; set; }
        public string OrderNumber { get; set; }
        public double Total { get; set; }
        public DateTime  OrderDate { get; set; }
        public OrderState  OrderState { get; set; }
        public string  UserName { get; set; }
        public string  Adres { get; set; }
        public string  Sehir { get; set; }

        public string Semt { get; set; }
        public string  Mahalle { get; set; }
        public string  PostaKodu { get; set; }

        public virtual List<Orderline> Orderlines { get; set; }



    }
    public class Orderline
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public virtual  Order Order { get; set; }
        public int Quantity { get; set; }
        public double     Price { get; set; }
        public int     ProductId { get; set; }
        public virtual Product Product { get; set; }






    }
}