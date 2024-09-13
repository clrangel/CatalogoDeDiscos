using Microsoft.AspNetCore.Mvc;

namespace CatalogoDeDiscos.Controllers
{
    public class ArtistBandsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
