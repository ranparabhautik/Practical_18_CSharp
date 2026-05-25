using Microsoft.EntityFrameworkCore;
using Practical_18.Models.Entities;

namespace Practical_18.Models.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions option):base(option)
        {
            
        }
        public DbSet<Student> Students { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().HasData(
                new Student {Id=1,FirstName="Bhautik",LastName="Ranpara",Address="Rajkot",Age=22,Mobile="9998887774" },
                new Student { Id = 2, FirstName = "Ted", LastName = "Mosby", Address = "Chicago", Age = 35, Mobile = "9995556623" },
                new Student { Id = 3, FirstName = "Barney", LastName = "Stinson", Address = "LA", Age = 26, Mobile = "6655448811" },
                new Student { Id = 4, FirstName = "Lily", LastName = "Aldrin", Address = "NYC", Age = 36, Mobile = "9988556633" },
                new Student { Id = 5, FirstName = "Robin", LastName = "Scherbatsky", Address = "Texas", Age = 30, Mobile = "4488556622" }
                );
        }
    }
}
