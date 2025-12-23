using Microsoft.AspNetCore.Mvc;

namespace CRM_API.Controllers
{
    public class VehiclesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
