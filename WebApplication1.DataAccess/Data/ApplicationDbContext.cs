using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;
namespace WebApplication1.DataAccess.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Category>().HasData(
               new Category { Id = 1, Name = "Fruits", DisplayOrder = 1 },
               new Category { Id = 2, Name = "Vegitables", DisplayOrder = 2 },
               new Category { Id = 3, Name = "DryFruits", DisplayOrder = 3 }

                );
            modelBuilder.Entity<Product>().HasData(

                new Product
                {
                    Id = 1,
                    Title = "Fruits",
                    Author = "AAAA",
                    Description = "Present In India",
                    ISBN = "SWD11223344",
                    ListPrice = 50,
                    Price = 20,
                    Price50 = 80,
                    Price100 = 90,
                    CategoryId = 1
                },
                  new Product
                  {
                      Id = 2,
                      Title = "Dry-Fruits",
                      Author = "BBBB",
                      Description = "Present In India",
                      ISBN = "SWD224466",
                      ListPrice = 60,
                      Price = 90,
                      Price50 = 80,
                      Price100 = 90,
                      CategoryId = 2
                  },
                   new Product
                   {
                       Id = 3,
                       Title = "Fruits_1",
                       Author = "FFFF",
                       Description = "Present In China",
                       ISBN = "45tgghh",
                       ListPrice = 60,
                       Price = 90,
                       Price50 = 80,
                       Price100 = 90,
                       CategoryId = 3
                   }
                );
        }
    }
}
