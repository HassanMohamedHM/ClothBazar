using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClothBazar.Entities;
using ClothBazar.DataBase;
namespace ClothBazar.Services
{
    public class CategoriesService
    {
        public Category GetCategory(int? ID)
        {
            using (var db = new CBContext())
            {
                return db.Categories.Find(ID);
            }
        }
        public List<Category> GetCategories()
        {
            using (var db = new CBContext())
            {
                return db.Categories.ToList();
            }
        }
        public void SaveCategory(Category Category)
        {
            using (var db = new CBContext())
            {
                db.Categories.Add(Category);
                db.SaveChanges();
            }
        }
        public void UpdateCategory(Category Category)
        {
            using (var db = new CBContext())
            {
                db.Entry<Category>(Category).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }
        public void DeleteCategory(int ID)
        {
            using (var db = new CBContext())
            {
                db.Categories.Remove(db.Categories.Find(ID));
                db.SaveChanges();
            }
        }
    }
}
