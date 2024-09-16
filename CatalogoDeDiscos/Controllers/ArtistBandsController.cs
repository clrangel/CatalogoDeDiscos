using CatalogoDeDiscos.Services;
using Microsoft.AspNetCore.Mvc;

namespace CatalogoDeDiscos.Controllers
{
    public class ArtistBandsController : Controller
    {

        private readonly ArtistBandService _bandService;

        public ArtistBandsController(ArtistBandService bandService)
        {
            _bandService = bandService;
        }

        public IActionResult Index()
        {
            var list = _bandService.FindAll();
            
            return View(list);

        }
    }
}
