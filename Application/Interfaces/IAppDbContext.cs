using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Interfaces
{
    public interface IAppDbContext
    {
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Owner> RestaurantOwners { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<RestaurantEmployee> RestaurantEmployees { get; set; }
        public DbSet<Chat> ChatBoxes { get; set; }
        public DbSet<ChatMessage> Messages { get; set; }
        public DbSet<WorkingDay> WorkingDays { get; set; }
        public DbSet<ShoppingList> ShoppingLists { get; set; }
        public DbSet<ShoppingListProduct> ShoppingListProducts { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Warehouse> Warehouses { get; set; }
    }
}
