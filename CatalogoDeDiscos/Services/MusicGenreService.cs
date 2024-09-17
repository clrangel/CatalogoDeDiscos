using CatalogoDeDiscos.Data;
using CatalogoDeDiscos.Models;

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
        public List<MusicGenre> FindAll()
        {
            return _context.MusicGenre.OrderBy(x => x.Genre).ToList();
        }

        public void Insert(MusicGenre obj)
        {
            _context.Add(obj);
            _context.SaveChanges();
        }

    }
}
