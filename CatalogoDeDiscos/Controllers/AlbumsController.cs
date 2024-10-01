using CatalogoDeDiscos.Models;
using CatalogoDeDiscos.Models.ViewModels;
using CatalogoDeDiscos.Services;
using CatalogoDeDiscos.Services.Exceptions;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

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
        public async Task<IActionResult> Index()
        {
            var list = await _albumService.FindAllAsync();

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
        public async Task<IActionResult> Create(Album album) 
        { 
            await _albumService.InsertAsync(album);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                //return NotFound();
                return RedirectToAction(nameof(Error), new { message = "Id not provided!" });
            }

            var obj = await _albumService.FindByIdAsync(id.Value);
            if (obj == null)
            {
                //return NotFound();
                RedirectToAction(nameof(Error), new { message = "Id not found!" });
            }
            
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _albumService.RemoveAsync(id);
                return RedirectToAction(nameof(Index));
            }
            catch (IntegrityException e)
            {
                return RedirectToAction(nameof(Error), new { message = e.Message });
            }
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                //return NotFound();
                return RedirectToAction(nameof(Error), new { message = "Id not provided!" });
            }

            var obj = await _albumService.FindByIdAsync(id.Value);
            if (obj == null)
            {
                //return NotFound();
                return RedirectToAction(nameof(Error), new { message = "Id not provided!" });
            }

            return View(obj);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                //return NotFound();
                return RedirectToAction(nameof(Error), new { message = "Id not provided!" });
            }

            var obj = await _albumService.FindByIdAsync(id.Value);
            if (obj == null)
            {
                //return NotFound();
                return RedirectToAction(nameof(Error), new { message = "Id not provided!" });
            }

            List<ArtistBand> artistBands = await _artistBandService.FindAllAsync();
            AlbumFormViewModel viewModel = new AlbumFormViewModel { Album = obj, ArtistBands = artistBands };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Album album)
        {
            if(id != album.Id)
            {
                //return BadRequest();
                return RedirectToAction(nameof(Error), new { message = "Id mismatch!" });
            }
            try
            {
                await _albumService.UpdateAsync(album);
                return RedirectToAction(nameof(Index));
            }
            catch (ApplicationException e) //Dois tratamentos idênticos para as exceções, utiliza-se upcasting para ambas. 
            {
                //return NotFound();
                return RedirectToAction(nameof(Error), new { message = e.Message });
            }
            /*catch (NotFoundException e)
            {
                //return NotFound();
                return RedirectToAction(nameof(Error), new { message = e.Message });
            }
            catch (DbConcurrencyException e)
            {
                //return BadRequest();
                return RedirectToAction(nameof(Error), new { message = e.Message });
            }*/
        }

        public IActionResult Error(string message)
        {
            var viewModel = new ErrorViewModel
            {
                Message = message,
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            };
            return View(viewModel);
        }

        
        public async Task<IActionResult> SearchAlbumsYear(DateTime? minDate, DateTime? maxDate)
        {
            if (!minDate.HasValue)
            {
                minDate = new DateTime(DateTime.Now.Year, 1, 1);
            }
            if (!maxDate.HasValue)
            {
                maxDate = DateTime.Now;
            }
            ViewData["minDate"] = minDate.Value.ToString("dd-MM-yyyy");
            ViewData["maxDate"] = maxDate.Value.ToString("dd-MM-yyyy");
            var result = await _albumService.FindByDateAsync(minDate, maxDate);
            return View(result);
        }
        
    }
}
