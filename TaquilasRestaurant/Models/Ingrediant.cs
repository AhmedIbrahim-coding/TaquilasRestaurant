using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace TaquilasRestaurant.Models
{
    public class Ingrediant
    {
        public int IngrediantId { get; set; }
        public string Name { get; set; }

        [ValidateNever]
        public ICollection<ProductIngrediant> ProductIngrediants { get; set; }
    }
}
