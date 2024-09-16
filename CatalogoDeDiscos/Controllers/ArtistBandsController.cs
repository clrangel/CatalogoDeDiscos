using CatalogoDeDiscos.Models;
using CatalogoDeDiscos.Services;
using Microsoft.AspNetCore.Mvc;

namespace CatalogoDeDiscos.Controllers
{
    public class ArtistBandsController : Controller
    {

        private readonly ArtistBandService _artistBandService;

        public ArtistBandsController(ArtistBandService ArtistBandService)
        {
            _artistBandService = ArtistBandService;
        }

        public IActionResult Index()
        {
            var list = _artistBandService.FindAll();
            
            return View(list);

        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ArtistBand artistBand) 
        {
            _artistBandService.Insert(artistBand);

            return RedirectToAction(nameof(Index));
        }
       
    }
}
