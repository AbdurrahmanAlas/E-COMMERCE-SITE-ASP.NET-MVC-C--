using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
namespace Tıcaret2020.Entity
{
    //DBCONTEXT İ EKLİYORUZ KALITIM ÖZELLİĞİ 
    public class DataContext:DbContext

    {

        //datainitializeri oluşturduktan sonra
        public DataContext():base("dataConnection")
        {
            Database.SetInitializer(new DataInitializer());
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categoris { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Orderline> Orderlines { get; set; }
        public DbSet<Kullanıcı> Kullanıcıs { get; set; }





    }
}