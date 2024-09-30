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
        public async Task<List<Album>> FindAllAsync()
        {
            //return _context.Album.ToList();
            return await _context.Album.Include(obj => obj.ArtistBand).OrderBy(x => x.ArtistBand).ToListAsync();
        }

        public async Task InsertAsync(Album obj)
        {
            _context.Add(obj);
            await _context.SaveChangesAsync();
        }

        public async Task<Album> FindByIdAsync(int id)
        {
            return await _context.Album.Include(obj => obj.ArtistBand).FirstOrDefaultAsync(obj => obj.Id == id);
        }

        public async Task RemoveAsync(int id)
        {
            try
            {
                var obj = await _context.Album.FindAsync(id);
                _context.Album.Remove(obj);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException e)
            {
                throw new IntegrityException(e.Message);
            }
        }

        public async Task UpdateAsync(Album obj)
        {
            bool hasAny = await _context.Album.AnyAsync(x => x.Id == obj.Id);
            if (!hasAny)
            {
                throw new NotFoundException("Id not found");
            }
            try
            {
                _context.Update(obj);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException e)
            {
                throw new DbUpdateConcurrencyException(e.Message);
            }
        }
    }
}
