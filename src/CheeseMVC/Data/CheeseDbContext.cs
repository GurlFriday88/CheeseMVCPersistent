using CheeseMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace CheeseMVC.Data
{
    public class CheeseDbContext : DbContext
    {
        private DbSet<CheeseCategory> _categories;

        public DbSet<Cheese> Cheeses { get; set; }
        public DbSet<CheeseCategory> Categories { get => _categories; set => _categories = value; }
        public DbSet <Menu> Menus{ get; set; }
        public DbSet <CheeseMenu> CheeseMenus{ get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        { //This method sets the primary key of the CheeseMenu class and table to be a composite key of both CheeseID and MenuID
            modelBuilder.Entity<CheeseMenu>()
                .HasKey(c => new { c.CheeseID, c.MenuID });
        }

        public CheeseDbContext(DbContextOptions<CheeseDbContext> options)
            : base(options)
        { }

    }
}
