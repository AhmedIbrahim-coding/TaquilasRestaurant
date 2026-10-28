using Microsoft.AspNetCore.Mvc;
using TaquilasRestaurant.Data;
using TaquilasRestaurant.Models;

namespace TaquilasRestaurant.Controllers
{
    public class IngrediantController : Controller
    {
        private Repository<Ingrediant> ingrediants;

        public IngrediantController(ApplicationDbContext context)
        {
            ingrediants = new Repository<Ingrediant>(context);
        }
        public async Task<IActionResult> Index()
        {
            return View(await ingrediants.GetAllAsync());
        }

        public async Task<IActionResult> Details(int id)
        {
            return View(await ingrediants.GetById(id, new QueryOptions<Ingrediant>() { Includes = "ProductIngrediants.Product" }));
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IngrediantId", "Name")] Ingrediant ingrediant)
        {
            if (ModelState.IsValid)
            {
                await ingrediants.AddAsync(ingrediant);
                return RedirectToAction("Index");
            }
            return View(ingrediant);
     
        }

    }
}
