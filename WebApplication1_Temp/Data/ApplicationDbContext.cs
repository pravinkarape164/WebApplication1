using Microsoft.Build.Construction;
using Microsoft.EntityFrameworkCore;
using WebApplication1_Temp.Models;

namespace WebApplication1_Temp.Data
{
    public class ApplicationDbContext :DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options ) :base(options)
        {
                
        }
         public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                 new Category { Id = 1, Name = "Fruits", DisplayOrder = 1 },
               new Category { Id = 2, Name = "Vegitables", DisplayOrder = 2 },
               new Category { Id = 3, Name = "DryFruits", DisplayOrder = 3 }

                );
        }
    }
}
