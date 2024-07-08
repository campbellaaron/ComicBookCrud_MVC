using ComicBookCrud.Models;
using Microsoft.EntityFrameworkCore;

namespace ComicBookCrud.DataAccess.Data
{
    public class ComicCrudDbContext : DbContext
    {
        public ComicCrudDbContext(DbContextOptions<ComicCrudDbContext> options) : base(options)
        {
               
        }

        // Add DB Set for each table. Hoping to include Categories, Publishers (DC, Marvel, etc), and a third one. Still working on that. 
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { Id=1, Name="Action", DisplayOrder=1},
                new Category { Id=2, Name="Sci-Fi", DisplayOrder=2},
                new Category { Id=3, Name="Gritty", DisplayOrder=3}
            );
        }
    }
}
