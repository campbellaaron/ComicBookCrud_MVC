using ComicBooksWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace ComicBooksWeb.Data
{
    public class ComicCrudDbContext : DbContext
    {
        public ComicCrudDbContext(DbContextOptions<ComicCrudDbContext> options) : base(options)
        {
               
        }

        public DbSet<Category> Categories { get; set; }
    }
}
