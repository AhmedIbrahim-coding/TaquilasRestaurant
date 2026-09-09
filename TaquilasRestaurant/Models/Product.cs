using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaquilasRestaurant.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public int CategoryId { get; set; }
        [NotMapped]
        public IFormFile ImageFile { get; set; }
        public string ImageUrl { get; set; } = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQHTPPGo9g_DgIYiC7pT9c0y_6KGk0D1tykW6zRwytfuw&s=10";

        [ValidateNever]
        public Category Category { get; set; }

        [ValidateNever]
        public ICollection<OrderItem> OrderItems { get; set; }

        [ValidateNever]
        public ICollection<ProductIngrediant> ProductIngrediants { get; set; }

    }
}