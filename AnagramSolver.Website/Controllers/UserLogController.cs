using Microsoft.AspNetCore.Mvc;

namespace AnagramSolver.Website.Controllers
{
    public class UserLogController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
