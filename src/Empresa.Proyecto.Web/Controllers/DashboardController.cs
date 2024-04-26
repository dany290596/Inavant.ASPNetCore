using Microsoft.AspNetCore.Mvc;

namespace Empresa.Proyecto.Web.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
