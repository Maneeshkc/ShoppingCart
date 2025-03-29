using Microsoft.AspNetCore.Mvc;
using ShoppingCart.DataAccess;
using ShoppingCart.Models;

namespace ShoppingCart.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ShoppingCartContext _context;
        public CategoryController(ShoppingCartContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<Models.Category> items = _context.Categories.ToList();
            return View(items);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Category cat)
        {
            if(cat.DisplayOrder<=0)
            {
                ModelState.AddModelError("", "Display order should be Greater than 0");
            }
            if (ModelState.IsValid)
            {
                _context.Categories.Add(cat);
                _context.SaveChanges();
                TempData["notification"] = "Succefully Created.";

                return RedirectToAction("Index");

            }
            return View();
        }

        public IActionResult Update(int id)
        {
            var item = _context.Categories.Find(id);
            return View(item);
        }

        [HttpPost]
        public IActionResult Update(Category cat)
        {
            if (cat.DisplayOrder <= 0)
            {
                ModelState.AddModelError("", "Display order should be Greater than 0");
            }
            if (ModelState.IsValid)
            {
                _context.Categories.Update(cat);
                _context.SaveChanges();
                TempData["notification"] = "Succefully updated.";
                return RedirectToAction("Index");

            }
            return View();
        }

        public IActionResult Delete(int id)
        {
            var item=_context.Categories.Find(id);
            return View(item);
        }

        [HttpPost,ActionName("Delete")]
        public IActionResult DeleteCategory(int id)
        {

            Category? item = _context.Categories.Find(id);
            _context.Categories.Remove(item);
            _context.SaveChanges();
            TempData["notification"] = "Succefully Deleted.";

            return RedirectToAction("Index");

        }
    }
}
