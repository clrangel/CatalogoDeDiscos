using CatalogoDeDiscos.Services;
using Microsoft.AspNetCore.Mvc;

namespace CatalogoDeDiscos.Controllers
{
    public class AlbumsController : Controller
    {
        private readonly AlbumService _albumService;

        public AlbumsController(AlbumService albumService)
        {
            _albumService = albumService;
        }
        public IActionResult Index()
        {
            var list = _albumService.FindAll();

            return View(list);
        }
    }
}
