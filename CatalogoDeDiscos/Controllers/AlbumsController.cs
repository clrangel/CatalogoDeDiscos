using Microsoft.AspNetCore.Mvc;

namespace CatalogoDeDiscos.Controllers
{
    public class AlbumsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
