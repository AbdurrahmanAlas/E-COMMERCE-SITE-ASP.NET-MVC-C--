using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tıcaret2020.Entity;

namespace Tıcaret2020.Models
{
    //CART :SEPET İ OLUŞTURUYORUZ.





    //SEPETTEKİ TÜM ÜRÜNLERİ TEMSİL EDER
    public class Cart
    {


        //ALIŞVERİŞ SEPETİNDE TEK BİR ÜRÜNÜ TEMSİL EDER.
        private List<Cartline> _cartLines = new List<Cartline>();        //kart içine birden fazla ürün olduğu için sadece kullanıcı erişebilir
        public List<Cartline> Cartlines
        {
            get
            {
                return _cartLines;

            }
        }






        //TEK BİR SATIRI İFADE EDER
        public class Cartline
        {

            public Product Product { get; set; }
            public int Quantity { get; set; }



        }




        //ÜRÜN EKLEME Product Sınfından bir tane product alması lazım .bu üründen kaç tane sepete eklememiz gerek quantity 
        public void AddProduct(Product product, int quantity)
        {
            var line = _cartLines.FirstOrDefault(i => i.Product.Id == product.Id);
            //eklediğimiz ürün sepette var mı yok mu  


            //Ürün sepette var m yok mu kontrol ediyoruz.
            if (line == null)
            {
                // sepette yoksa ekliyoruz.
                _cartLines.Add(new Cartline() { Product = product, Quantity = quantity });
                // yeni bir kart oluşturup ürün ve sayısını ekledik  .

            }
            else
            {


                line.Quantity = quantity;


            }

        }




        //ÜRÜN SİLİYORUZ.
        public void DeleteProduct(Product product)
        {
            _cartLines.RemoveAll(i => i.Product.Id == product.Id);


        }









        //TOPLAM ÜRÜNLERİ YAZIYORUZ.
        public double Total()
        {

            return _cartLines.Sum(i => i.Product.Price * i.Quantity);


        }







        //TÜM ÜRÜNLERİ TEK SEFERDE SİLER.
        public void Clear()
        {

            _cartLines.Clear();

        }

    }












}