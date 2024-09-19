using CatalogoDeDiscos.Models;
using CatalogoDeDiscos.Models.ViewModels;
using CatalogoDeDiscos.Services;
using CatalogoDeDiscos.Services.Exceptions;
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

        public IActionResult Edit(int? id) 
        { 
            if(id == null)
            {
                return NotFound();
            }

            var obj = _artistBandService.FindById(id.Value);
            if(obj == null)
            {
                return NotFound();
            }

            List<MusicGenre> musicGenres = _musicGenreService.FindAll();
            ArtistBandFormViewModel viewModel = new ArtistBandFormViewModel { ArtistBand = obj, MusicGenres = musicGenres };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, ArtistBand artistBand)
        {
            if(id != artistBand.Id)
            {
                return BadRequest();
            }
            try
            {
                _artistBandService.Update(artistBand);
                return RedirectToAction(nameof(Index));
            }
            catch (NotFoundException e)
            {
                return NotFound();
            }
            catch(DbConcurrencyException e)
            {
                return BadRequest();
            }
            

        }

    }
}
