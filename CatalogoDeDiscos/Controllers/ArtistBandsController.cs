using CatalogoDeDiscos.Models;
using CatalogoDeDiscos.Models.ViewModels;
using CatalogoDeDiscos.Services;
using CatalogoDeDiscos.Services.Exceptions;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

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

        public async Task<IActionResult> Index()
        {
            var list = await _artistBandService.FindAllAsync();
            
            return View(list);

        }

        public async Task<IActionResult> Create()
        {
            var musicGenres = await _musicGenreService.FindAllAsync();
            var viewModel = new ArtistBandFormViewModel { MusicGenres = musicGenres };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ArtistBand artistBand) 
        {
            await _artistBandService.InsertAsync(artistBand);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                //return NotFound();
                return RedirectToAction(nameof(Error), new { message = "Id not provided!" });
            }
            var obj = await _artistBandService.FindByIdAsync(id.Value);
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
            await _artistBandService.RemoveAsync(id);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                //return NotFound();
                RedirectToAction(nameof(Error), new { message = "Id not provided!" });
            }
            var obj = await _artistBandService.FindByIdAsync(id.Value);
            if (obj == null)
            {
                //return NotFound();
                return RedirectToAction(nameof(Error), new { message = "Id not found!" });
            }
            return View(obj);
        }

        public async Task<IActionResult> Edit(int? id) 
        { 
            if(id == null)
            {
                //return NotFound();
                return RedirectToAction(nameof(Error), new { message = "Id not provided!" });
            }

            var obj = await _artistBandService.FindByIdAsync(id.Value);
            if(obj == null)
            {
                //return NotFound();
                return RedirectToAction(nameof(Error), new { message = "Id not found!" });
            }

            List<MusicGenre> musicGenres = await _musicGenreService.FindAllAsync();
            ArtistBandFormViewModel viewModel = new ArtistBandFormViewModel { ArtistBand = obj, MusicGenres = musicGenres };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ArtistBand artistBand)
        {
            if(id != artistBand.Id)
            {
                //return BadRequest();
                return RedirectToAction(nameof(Error), new { message = "Id mismatch!" });
            }
            try
            {
                await _artistBandService.UpdateAsync(artistBand);
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

    }
}
