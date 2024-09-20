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
        public async Task<List<ArtistBand>> FindAllAsync()
        {
            return await _context.ArtistBand.ToListAsync();
        }

        public async Task InsertAsync(ArtistBand obj)
        {
            _context.Add(obj);
            await _context.SaveChangesAsync();
        }

        public async Task<ArtistBand> FindByIdAsync(int id)
        {
            return await _context.ArtistBand.Include(obj => obj.MusicGenre).FirstOrDefaultAsync(obj => obj.Id == id);
        }
        public async Task RemoveAsync(int id)
        {
            try
            {
                var obj = await _context.ArtistBand.FindAsync(id);
                _context.ArtistBand.Remove(obj);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException e)
            {
                throw new IntegrityException(e.Message);
            }
        }


        public async Task UpdateAsync(ArtistBand obj)
        {
            bool hasAny = await _context.ArtistBand.AnyAsync(x => x.Id == obj.Id);
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
