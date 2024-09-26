using CatalogoDeDiscos.Models;
using CatalogoDeDiscos.Models.ViewModels;
using CatalogoDeDiscos.Services;
using Microsoft.AspNetCore.Mvc;

namespace CatalogoDeDiscos.Controllers
{
    public class AlbumsController : Controller
    {
        private readonly AlbumService _albumService;
        private readonly ArtistBandService _artistBandService;

        public AlbumsController(AlbumService albumService, ArtistBandService artistBandService)
        {
            _albumService = albumService;
            _artistBandService = artistBandService;
        }
        public IActionResult Index()
        {
            var list = _albumService.FindAll();

            return View(list);
        }

        public async Task<IActionResult> Create()
        {
            var artistBands = await _artistBandService.FindAllAsync();
            var viewModel = new AlbumFormViewModel { ArtistBands = artistBands };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Album album) 
        { 
            _albumService.Insert(album);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var obj = _albumService.FindById(id.Value);
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
            _albumService.Remove(id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var obj = _albumService.FindById(id.Value);
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }
    }
}
