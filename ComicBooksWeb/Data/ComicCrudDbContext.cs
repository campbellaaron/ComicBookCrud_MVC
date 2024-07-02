using Microsoft.EntityFrameworkCore;

namespace ComicBooksWeb.Data
{
    public class ComicCrudDbContext : DbContext
    {
        public ComicCrudDbContext(DbContextOptions<DbContext> options) : base(options)
        {
            
        }
    }
}
