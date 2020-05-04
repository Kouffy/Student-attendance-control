using Microsoft.AspNetCore.Mvc;

namespace MiniProjet_alpha.Controllers
{
    public class AccueilController : Controller
    {
        public AccueilController(){}
        public IActionResult Index()
        {
            return View();
        }
    }
}