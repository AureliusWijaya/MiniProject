using Microsoft.EntityFrameworkCore;
using WearHouse.Models;

namespace WearHouse.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() { }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           modelBuilder.Entity<Category>().HasData(
                             new Category { CategoryId = 1, CategoryName = "Bajuu" },
                             new Category { CategoryId = 2, CategoryName = "Celana" },
                             new Category { CategoryId = 3, CategoryName = "Sepatuu" },
                             new Category { CategoryId = 4, CategoryName = "Topi" },
                             new Category { CategoryId = 5, CategoryName = "Kemeja" }
                             );
            modelBuilder.Entity<User>().HasData(
              new User { UserId = new System.Guid("f5a3a9b0-3e9c-4b1e-9f1a-6e8f1d1b1a1a"), Name = "Orang1", Email = "asd@gmail.com", Password = "12312312" }
              );
        }
            
        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
