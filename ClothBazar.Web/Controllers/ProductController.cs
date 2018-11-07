using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ClothBazar.Services;
using ClothBazar.Entities;

namespace ClothBazar.Web.Controllers
{
    public class ProductController : Controller
    {
        ProductsService productsService = new ProductsService();

        // GET: Product
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult ProductTable(string search)
        {
            if (search == null)
            {
                return PartialView(productsService.GetProducts());
            }
            return PartialView(productsService.GetProducts().Where(p => p.Name.ToLower().Contains(search.ToLower())).ToList());
        }
        [HttpGet]
        public ActionResult Create()
        {
            return PartialView();
        }
        [HttpPost]
        public ActionResult Create(Product product)
        {
            productsService.SaveProduct(product);
            return RedirectToAction("ProductTable");
        }
        [HttpGet]
        public ActionResult Edit(int ID)
        {
            return PartialView(productsService.GetProduct(ID));
        }
        [HttpPost]
        public ActionResult Edit(Product product)
        {
            productsService.UpdateProduct(product);
            return RedirectToAction("ProductTable");
        }
        [HttpPost]
        public ActionResult Delete(int ID)
        {
            productsService.DeleteProduct(ID);
            return RedirectToAction("ProductTable");
        }
    }
}