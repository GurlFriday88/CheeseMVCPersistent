using CheeseMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace CheeseMVC.Data
{
    public class CheeseDbContext : DbContext
    {
        private DbSet<CheeseCategory> _categories;

        public DbSet<Cheese> Cheeses { get; set; }
        public DbSet<CheeseCategory> Categories { get => _categories; set => _categories = value; }

        public CheeseDbContext(DbContextOptions<CheeseDbContext> options)
            : base(options)
        { }

    }
}
