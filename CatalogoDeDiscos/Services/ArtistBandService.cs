using CatalogoDeDiscos.Data;
using CatalogoDeDiscos.Models;
using CatalogoDeDiscos.Services.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace CatalogoDeDiscos.Services
{
    public class ArtistBandService
    {
        private readonly CatalogoDeDiscosContext _context;

        public ArtistBandService(CatalogoDeDiscosContext context)
        {
            _context = context;
        }

        //Retorna uma lista com todas as bandas do banco de dados.
        public List<ArtistBand> FindAll()
        {
            return _context.ArtistBand.ToList();
        }

        public void Insert(ArtistBand obj)
        {
            _context.Add(obj);
            _context.SaveChanges();
        }

        public ArtistBand FindById(int id)
        {
            return _context.ArtistBand.Include(obj => obj.MusicGenre).FirstOrDefault(obj => obj.Id == id);
        }
        public void Remove(int id)
        {
            var obj = _context.ArtistBand.Find(id);
            _context.ArtistBand.Remove(obj);
            _context.SaveChanges();
        }

        public void Update(ArtistBand obj)
        {
            if (!_context.ArtistBand.Any(x => x.Id == obj.Id))
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
