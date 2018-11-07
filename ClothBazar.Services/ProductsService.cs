using ClothBazar.DataBase;
using ClothBazar.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothBazar.Services
{
    public class ProductsService
    {
        public Product GetProduct(int? ID)
        {
            using (var db = new CBContext())
            {
                return db.Products.Find(ID);
            }
        }
        public List<Product> GetProducts()
        {
            using (var db = new CBContext())
            {
                return db.Products.ToList();
            }
        }
        public void SaveProduct(Product Product)
        {
            using (var db = new CBContext())
            {
                db.Products.Add(Product);
                db.SaveChanges();
            }
        }
        public void UpdateProduct(Product Product)
        {
            using (var db = new CBContext())
            {
                db.Entry<Product>(Product).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }
        public void DeleteProduct(int ID)
        {
            using (var db = new CBContext())
            {
                db.Products.Remove(db.Products.Find(ID));
                db.SaveChanges();
            }
        }
    }
}
