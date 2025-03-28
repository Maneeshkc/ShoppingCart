using Microsoft.AspNetCore.Mvc;
using ShoppingCart.Data;

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
            List<Models.Category> items =_context.Categories.ToList();
            return View(items);
        }
    }
}
