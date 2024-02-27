using Microsoft.AspNetCore.Mvc;
using Mission08_Team0315.Models;
using System.Diagnostics;

namespace Mission08_Team0315.Controllers
{
    public class HomeController : Controller
    {

        private readonly TaskContext _context;

        public HomeController(TaskContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {




            return RedirectToAction("Quadrants");
        }
        public IActionResult Quadrants()
        {

            var Tasks = _context.Tasks.ToList();



            return View(Tasks);
        }

        public IActionResult Completed()
        {


            return RedirectToAction("Quadrants");
        }



    }
}
