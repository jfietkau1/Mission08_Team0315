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

            var Tasks = _context.Tasks.ToList();



            return View(Tasks);
        }

        public IActionResult Completed()
        {


            return RedirectToAction("Quadrants");
        }
        public IActionResult AddTask()
        {


            return RedirectToAction("Quadrants");
        }

        public async Task<IActionResult> EditTask(Task taskToUpdate)
        {
            if (taskToUpdate == null || taskToUpdate.TaskId == 0)
            {
                return NotFound();
            }

            var existingTask = await _context.Tasks.FirstOrDefaultAsync(t => t.TaskId == taskToUpdate.TaskId);

            if (existingTask != null)
            {
                existingTask.TaskName = taskToUpdate.TaskName;
                existingTask.DueDate = taskToUpdate.DueDate;
                existingTask.Quadrant = taskToUpdate.Quadrant;
                existingTask.CategoryId = taskToUpdate.CategoryId;
                existingTask.IsCompleted = taskToUpdate.IsCompleted;

                try
                {
                    _context.Update(existingTask);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Tasks.Any(t => t.TaskId == taskToUpdate.TaskId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }

            return RedirectToAction("Quadrants");
        }
    }
}
