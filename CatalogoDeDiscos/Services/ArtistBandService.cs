using CatalogoDeDiscos.Data;
using CatalogoDeDiscos.Models;

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
    }
}
