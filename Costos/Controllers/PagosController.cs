using Microsoft.AspNetCore.Mvc;

namespace Costos.Controllers
{
    public class PagosController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
