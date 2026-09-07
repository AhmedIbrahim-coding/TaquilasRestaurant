using Microsoft.AspNetCore.Identity;
using System.Collections.ObjectModel;

namespace TaquilasRestaurant.Models
{
    public class ApplicationUser : IdentityUser
    {
        public ICollection<Order> Orders { get; set; }
    }
}
