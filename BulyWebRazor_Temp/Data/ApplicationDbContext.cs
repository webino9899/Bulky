using BulyWebRazor_Temp.Model;
using Microsoft.EntityFrameworkCore;

namespace BulyWebRazor_Temp.Data
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
                new Category { ID = 1, Name = "TV", DisplayOrder = 2 },
                new Category { ID = 2, Name = "TAB", DisplayOrder = 1 }
                );
    }

    }
} 

