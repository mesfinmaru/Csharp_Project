using Microsoft.AspNetCore.Mvc;

namespace CRM_API.Controllers
{
    public class RentalsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
