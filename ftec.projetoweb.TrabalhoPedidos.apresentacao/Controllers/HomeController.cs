using Microsoft.AspNetCore.Mvc;

namespace ftec.projetoweb.TrabalhoPedidos.apresentacao.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
