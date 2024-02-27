using Microsoft.AspNetCore.Mvc;
using Mission08_Team0315.Models;
using System.Diagnostics;

namespace Mission08_Team0315.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Quadrants()
        {
            return View();
        }

    }
}
