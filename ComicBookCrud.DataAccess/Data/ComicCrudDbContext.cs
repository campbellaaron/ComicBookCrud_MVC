using ComicBookCrud.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ComicBookCrud.DataAccess.Data
{
    public class ComicCrudDbContext : IdentityDbContext
    {
        public ComicCrudDbContext(DbContextOptions<ComicCrudDbContext> options) : base(options)
        {
               
        }

        // Add DB Set for each table. Hoping to include Categories, Publishers (DC, Marvel, etc), and a third one. Still working on that. 
        public DbSet<Category> Categories { get; set; }
        public DbSet<ComicBook> ComicBooks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>().HasData(
                new Category { Id=1, Name="Action", DisplayOrder=1},
                new Category { Id=2, Name="Sci-Fi", DisplayOrder=2},
                new Category { Id=3, Name="Gritty", DisplayOrder=3}
            );
            modelBuilder.Entity<ComicBook>().HasData(
                new ComicBook 
                {
                    Id=1,
                    Title = "Black Orchid: Book One",
                    Issue = 1,
                    Description = "Two girls awaken in a greenhouse and encounter DC characters like Batman and Swamp Thing",
                    Author = "Neil Gaiman & Dave McKean",
                    Publisher = "DC Comics",
                    ListPrice = 11.99,
                    CoverPrice = 3.50,
                    CategoryId = 1,
                    ImageUrl = ""
                },
                new ComicBook 
                {
                    Id = 2,
                    Title = "Black Orchid: Book Two",
                    Issue = 2,
                    Description = "Black Orchid tries to remember her sister; Carl returns to get revenge on Philip for stealing his woman",
                    Author = "Neil Gaiman & Dave McKean",
                    Publisher = "DC Comics",
                    ListPrice = 12.99,
                    CoverPrice = 3.50,
                    CategoryId = 1,
                    ImageUrl = ""
                },
                new ComicBook 
                {
                    Id = 3,
                    Title = "w0rltr33",
                    Issue = 1,
                    Description = "Issues 1-5 of the infamouse \"w0rldtr33\" series. In 1999, Gabriel and his friends discover the Undernet -- a secret architecture to the Internet.",
                    Author = "James Tynion & Fernando Blanco",
                    Publisher = "Image Comics",
                    ListPrice = 9.99,
                    CoverPrice = 9.99,
                    CategoryId = 2,
                    ImageUrl = ""
                }
            );
        }
    }
}
