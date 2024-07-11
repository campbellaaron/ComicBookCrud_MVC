using ComicBookCrud.DataAccess.Data;
using ComicBookCrud.DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComicBookCrud.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {

        private ComicCrudDbContext _db;
        public ICategoryRepository Category {  get; private set; }
        public IComicBookRepository ComicBook { get; private set; }
        public UnitOfWork(ComicCrudDbContext db)
        {
            _db = db;
            Category = new CategoryRepository(_db);
            ComicBook = new ComicBookRepository(_db);
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
