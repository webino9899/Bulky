using BulkyWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace BulkyWeb.DataAcess.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { ID = 1, Name = "Varsha", DisplayOrder = 1 },
                new Category { ID = 2, Name = "Meera", DisplayOrder = 2 }
                );
        }
    }
}
