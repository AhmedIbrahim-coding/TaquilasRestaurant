using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TaquilasRestaurant.Models;

namespace TaquilasRestaurant.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        DbSet<Category> Categories { get; set; }
        DbSet<Product> Products { get; set; }
        DbSet<Order> Orders { get; set; }
        DbSet<OrderItem> OrderItems { get; set; }
        DbSet<ProductIngrediant> ProductIngrediants { get; set; }
        DbSet<Ingrediant> Ingrediants { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // define composite keys && relationships for ProductIngrediant entity
            builder.Entity<ProductIngrediant>()
                .HasKey(pi => new { pi.ProductId, pi.IngrediantId });

            builder.Entity<ProductIngrediant>()
                .HasOne(pi => pi.Product)
                .WithMany(p => p.ProductIngrediants)
                .HasForeignKey(pi => pi.ProductId);

            builder.Entity<ProductIngrediant>()
                .HasOne(pi => pi.Ingrediant)
                .WithMany(i => i.ProductIngrediants)
                .HasForeignKey(pi => pi.IngrediantId);

            // Seed Data for Categories
            builder.Entity<Category>().HasData(
                new Category { CategoryId = 1, Name = "Appetizer" },
                new Category { CategoryId = 2, Name = "Entree" },
                new Category { CategoryId = 3, Name = "Dessert" },
                new Category { CategoryId = 4, Name = "Side Dish" },
                new Category { CategoryId = 5, Name = "Beverage" }
                );

            builder.Entity<Ingrediant>().HasData(
                new Ingrediant { IngrediantId = 1, Name = "Beef" },
                new Ingrediant { IngrediantId = 2, Name = "Chicken" },
                new Ingrediant { IngrediantId = 3, Name = "Fish" },
                new Ingrediant { IngrediantId = 4, Name = "Tortilla" },
                new Ingrediant { IngrediantId = 5, Name = "Cheese" },
                new Ingrediant { IngrediantId = 6, Name = "Tomato" },
                new Ingrediant { IngrediantId = 7, Name = "Lettuce" }
                );

            builder.Entity<Product>().HasData(
                new Product
                {
                    ProductId = 1,
                    Name = "Beef Taco",
                    Description = "A delicious Beef taco",
                    Price = 3.99m,
                    Stock = 100,
                    CategoryId = 2
                },
                new Product
                {
                    ProductId = 2,
                    Name = "Chicken Taco",
                    Description = "A delicious Chicken taco",
                    Price = 3.49m,
                    Stock = 121,
                    CategoryId = 2
                },
                new Product
                {
                    ProductId = 3,
                    Name = "Fish Taco",
                    Description = "A delicious Fish taco",
                    Price = 4.49m,
                    Stock = 90,
                    CategoryId = 2
                }
                );

            builder.Entity<ProductIngrediant>().HasData(
                new ProductIngrediant { ProductId = 1, IngrediantId = 1 },
                new ProductIngrediant { ProductId = 1, IngrediantId = 4 },
                new ProductIngrediant { ProductId = 1, IngrediantId = 6 },
                new ProductIngrediant { ProductId = 1, IngrediantId = 7 },
                new ProductIngrediant { ProductId = 2, IngrediantId = 2 },
                new ProductIngrediant { ProductId = 2, IngrediantId = 4 },
                new ProductIngrediant { ProductId = 2, IngrediantId = 6 },
                new ProductIngrediant { ProductId = 2, IngrediantId = 7 },
                new ProductIngrediant { ProductId = 3, IngrediantId = 3 },
                new ProductIngrediant { ProductId = 3, IngrediantId = 4 },
                new ProductIngrediant { ProductId = 3, IngrediantId = 6 },
                new ProductIngrediant { ProductId = 3, IngrediantId = 7 }
                );
        }
    }
}
