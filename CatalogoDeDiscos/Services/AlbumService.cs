using CatalogoDeDiscos.Data;
using CatalogoDeDiscos.Models;
using CatalogoDeDiscos.Services.Exceptions;
using Microsoft.EntityFrameworkCore;

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
            return _context.Album.Include(obj => obj.ArtistBand).OrderBy(x => x.ArtistBand).ToList();
        }

        public void Insert(Album obj)
        {
            _context.Add(obj);
            _context.SaveChanges();
        }

        public Album FindById(int id)
        {
            return _context.Album.Include(obj => obj.ArtistBand).FirstOrDefault(obj => obj.Id == id);
        }

        public void Remove(int id)
        {
            var obj = _context.Album.Find(id);
            _context.Album.Remove(obj);
            _context.SaveChanges();
        }

        public void Update(Album obj)
        {
            if(!_context.Album.Any(x => x.Id == obj.Id))
            {
                throw new NotFoundException("Id not found");
            }
            try
            {
                _context.Update(obj);
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException e)
            {
                throw new DbUpdateConcurrencyException(e.Message);
            }
        }
    }
}
