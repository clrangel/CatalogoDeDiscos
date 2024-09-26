using CatalogoDeDiscos.Data;
using CatalogoDeDiscos.Models;

namespace CatalogoDeDiscos.Services
{
    public class AlbumService
    {
        private readonly CatalogoDeDiscosContext _context;

        public AlbumService(CatalogoDeDiscosContext context)
        {
            _context = context;
        }

        //Retorna uma lista com todos os discos do banco de dados.
        public List<Album> FindAll()
        {
            //return _context.Album.ToList();
            return _context.Album.OrderBy(x => x.ArtistBand).ToList();
        }

        public void Insert(Album obj)
        {
            _context.Add(obj);
            _context.SaveChanges();
        }

        public Album FindById(int id)
        {
            return _context.Album.FirstOrDefault(obj => obj.Id == id);
        }

        public void Remove(int id)
        {
            var obj = _context.Album.Find(id);
            _context.Album.Remove(obj);
            _context.SaveChanges();
        }
    }
}
