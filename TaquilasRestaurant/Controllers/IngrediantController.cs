using Microsoft.AspNetCore.Mvc;
using TaquilasRestaurant.Data;
using TaquilasRestaurant.Models;

namespace TaquilasRestaurant.Controllers
{
    public class IngrediantController : Controller
    {
        private IRepository<Ingrediant> ingrediants;

        public IngrediantController(IRepository<Ingrediant> ingrediants)
        {
            this.ingrediants = ingrediants;
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

        //Ingreadiant/Delete
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            await ingrediants.DeleteAsync(id);
            return RedirectToAction("Index");
        }

        //Ingreadiant/Edit
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            return View(await ingrediants.GetById(id, new QueryOptions<Ingrediant> { Includes = "ProductIngrediants.Product"}));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Ingrediant ingrediant)
        {
            if (ModelState.IsValid)
            {
                await ingrediants.UpdateAsync(ingrediant);
                return RedirectToAction("Index");
            }
            return View(ingrediant);
        }
    }
}
