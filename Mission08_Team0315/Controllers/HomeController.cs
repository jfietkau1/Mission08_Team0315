using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mission08_Team0315.Models;
using System.Diagnostics;
using Task = Mission08_Team0315.Models.Task;

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

            var Tasks = _context.Tasks.Where(x => x.IsCompleted == false).ToList();


            return View(Tasks);
        }

        public async Task<IActionResult> Completed(int id)
        {
            // Find the task by ID
            var taskToUpdate = await _context.Tasks.FirstOrDefaultAsync(t => t.TaskId == id);

            if (taskToUpdate != null)
            {
                // Change the IsCompleted status to true
                taskToUpdate.IsCompleted = true;

                // Save the changes to the database
                await _context.SaveChangesAsync();

                // Redirect to the 'Quadrants' view or any other appropriate action
                return RedirectToAction("Quadrants");
            }
            else
            {
                // If the task doesn't exist, return NotFound or any other appropriate response
                return NotFound();
            }
        }
        public IActionResult AddTask()
        {


            return RedirectToAction("Quadrants");
        }

        [HttpGet]
        public IActionResult EditTask(int id)
        {
            ViewBag.task = _context.Tasks.FirstOrDefault(x => x.TaskId == id);
            ViewBag.categories = _context.Categories.ToList();
            return RedirectToAction("AddTask");
        }


        
        [HttpPost]
        public async Task<IActionResult> EditTask(Task taskToUpdate)
        {

            if (ModelState.IsValid)
            {
                // Check if the task exists in the database
                var taskInDb = await _context.Tasks.FirstOrDefaultAsync(t => t.TaskId == taskToUpdate.TaskId);

                if (taskInDb == null)
                {
                    // If the task doesn't exist, return NotFound or any other appropriate response
                    return NotFound();
                }

                // Update the properties of the task in the database
                taskInDb.TaskName = taskToUpdate.TaskName;
                taskInDb.DueDate = taskToUpdate.DueDate;
                taskInDb.Quadrant = taskToUpdate.Quadrant;
                taskInDb.CategoryId = taskToUpdate.CategoryId;
                taskInDb.IsCompleted = taskToUpdate.IsCompleted;

                // Save the changes to the database
                await _context.SaveChangesAsync();

                // Redirect to the 'Quadrants' view or any other appropriate action
                return RedirectToAction("Quadrants");
            }


            return RedirectToAction("Quadrants");
        }
    }
}
