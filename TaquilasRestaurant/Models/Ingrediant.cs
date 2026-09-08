namespace TaquilasRestaurant.Models
{
    public class Ingrediant
    {
        public int IngrediantId { get; set; }
        public string Name { get; set; }
        public ICollection<ProductIngrediant> ProductIngrediants { get; set; }
    }
}
