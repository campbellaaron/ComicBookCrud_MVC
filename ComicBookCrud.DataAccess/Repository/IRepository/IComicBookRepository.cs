using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ComicBookCrud.Models;

namespace ComicBookCrud.DataAccess.Repository.IRepository
{
    public interface IComicBookRepository : IRepository<ComicBook>
    {
        void Update(ComicBook obj);
    }
}
