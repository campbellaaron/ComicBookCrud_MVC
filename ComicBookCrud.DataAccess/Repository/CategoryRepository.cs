using ComicBookCrud.DataAccess.Data;
using ComicBookCrud.DataAccess.Repository.IRepository;
using ComicBookCrud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ComicBookCrud.DataAccess.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private ComicCrudDbContext _db;
        public CategoryRepository(ComicCrudDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Category obj)
        {
            _db.Categories.Update(obj);
        }
    }
}
