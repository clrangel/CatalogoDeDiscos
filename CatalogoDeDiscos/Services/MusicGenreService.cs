using CatalogoDeDiscos.Data;
using CatalogoDeDiscos.Models;
using Microsoft.EntityFrameworkCore;

namespace CatalogoDeDiscos.Services
{
    public class MusicGenreService
    {
        private readonly CatalogoDeDiscosContext _context;

        public MusicGenreService(CatalogoDeDiscosContext context)
        {
            _context = context;
        }

        //Retorna uma lista com todos os gêneros do banco de dados.
        public async Task<List<MusicGenre>> FindAllAsync()
        {
            return await _context.MusicGenre.OrderBy(x => x.Genre).ToListAsync();
        }

        public void Insert(MusicGenre obj)
        {
            _context.Add(obj);
            _context.SaveChanges();
        }

    }
}
