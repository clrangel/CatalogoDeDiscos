using CatalogoDeDiscos.Models;
using CatalogoDeDiscos.Models.ViewModels;
using CatalogoDeDiscos.Services;
using Microsoft.AspNetCore.Mvc;

namespace CatalogoDeDiscos.Controllers
{
    public class ArtistBandsController : Controller
    {

        private readonly ArtistBandService _artistBandService;
        private readonly MusicGenreService _musicGenreService;

        public ArtistBandsController(ArtistBandService ArtistBandService, MusicGenreService musicGenreService)
        {
            _artistBandService = ArtistBandService;
            _musicGenreService = musicGenreService;
        }

        public IActionResult Index()
        {
            var list = _artistBandService.FindAll();
            
            return View(list);

        }

        public IActionResult Create()
        {
            var musicGenres = _musicGenreService.FindAll();
            var viewModel = new ArtistBandFormViewModel { MusicGenres = musicGenres };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ArtistBand artistBand) 
        {
            _artistBandService.Insert(artistBand);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var obj = _artistBandService.FindById(id.Value);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            _artistBandService.Remove(id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var obj = _artistBandService.FindById(id.Value);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

    }
}
