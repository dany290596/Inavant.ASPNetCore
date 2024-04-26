using Microsoft.AspNetCore.Mvc;

namespace Empresa.Proyecto.Web.Controllers
{
    public class CatalogosController : Controller
    {
        public IActionResult SimpleEntity()
        {
            return View();
        }
    }
}