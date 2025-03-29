using Microsoft.AspNetCore.Mvc;
using ShoppingCart.DataAccess;
using ShoppingCart.DataAccess.UnitOfWork;
using ShoppingCart.Models;

namespace ShoppingCart.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public CategoryController(IUnitOfWork context)
        {
            _unitOfWork = context;
        }
        public IActionResult Index()
        {
            List<Models.Category> items = _unitOfWork.Category.GetAll().OrderBy(x=>x.DisplayOrder).ToList();
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
                _unitOfWork.Category.Add(cat);
                _unitOfWork.Commit();
                TempData["notification"] = "Succefully Created.";

                return RedirectToAction("Index");

            }
            return View();
        }

        public IActionResult Update(int id)
        {
            var item = _unitOfWork.Category.Get(x=>x.Id== id);
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
                _unitOfWork.Category.Update(cat);
                _unitOfWork.Commit();
                TempData["notification"] = "Succefully updated.";
                return RedirectToAction("Index");

            }
            return View();
        }

        public IActionResult Delete(int id)
        {
            var item=_unitOfWork.Category.Get(x=>x.Id == id);
            return View(item);
        }

        [HttpPost,ActionName("Delete")]
        public IActionResult DeleteCategory(int id)
        {

            Category? item = _unitOfWork.Category.Get(x=>x.Id==id);
            _unitOfWork.Category.Delete(item);
            _unitOfWork.Commit();
            TempData["notification"] = "Succefully Deleted.";

            return RedirectToAction("Index");

        }
    }
}
