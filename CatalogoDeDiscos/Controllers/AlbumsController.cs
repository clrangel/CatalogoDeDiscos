using CatalogoDeDiscos.Models;
using CatalogoDeDiscos.Models.ViewModels;
using CatalogoDeDiscos.Services;
using CatalogoDeDiscos.Services.Exceptions;
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

        public async Task<IActionResult> Edit(int? id)
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

            List<ArtistBand> artistBands = await _artistBandService.FindAllAsync();
            AlbumFormViewModel viewModel = new AlbumFormViewModel { Album = obj, ArtistBands = artistBands };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Album album)
        {
            if(id != album.Id)
            {
                return BadRequest();
            }
            try
            {
                _albumService.Update(album);
                return RedirectToAction(nameof(Index));
            }
            catch(NotFoundException)
            {
                return NotFound();
            }
            catch (DbConcurrencyException)
            {
                return BadRequest();
            }
        }
    }
}
