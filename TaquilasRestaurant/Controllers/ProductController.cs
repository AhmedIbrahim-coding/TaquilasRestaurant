using Microsoft.AspNetCore.Mvc;
using TaquilasRestaurant.Models;

namespace TaquilasRestaurant.Controllers
{
    public class ProductController : Controller
    {
        public IRepository<Product> products;

        public ProductController(IRepository<Product> products)
        {
            this.products = products;
        }
        public async Task<IActionResult> Index()
        {
            return View(await products.GetAllAsync());
        }
    }
}
