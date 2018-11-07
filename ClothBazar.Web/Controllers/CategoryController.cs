using ClothBazar.Entities;
using ClothBazar.Services;
using System.Net;
using System.Web.Mvc;

namespace ClothBazar.Web.Controllers
{
    public class CategoryController : Controller
    {
        CategoriesService categoryService = new CategoriesService();
        [HttpGet]
        public ActionResult Index()
        {
            return View(categoryService.GetCategories());
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Category category)
        {
            categoryService.SaveCategory(category);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(int? ID)
        {
            if (ID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = categoryService.GetCategory(ID);
            if (category == null)
            {
                return HttpNotFound();
            }

            return View(category);
        }
        [HttpPost]
        public ActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                categoryService.UpdateCategory(category);
                return RedirectToAction("Index");
            }
            return View(category);
        }

        [HttpGet]
        public ActionResult Delete(int? ID)
        {
            if (ID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = categoryService.GetCategory(ID);
            if (category == null)
            {
                return HttpNotFound();
            }

            return View(category);
        }
        [HttpPost]
        public ActionResult Delete(int ID)
        {
            categoryService.DeleteCategory(ID);
            return RedirectToAction("Index");
        }
    }
}