using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mission08_Team0315.Models;
using System.Diagnostics;
using Task = Mission08_Team0315.Models.Task;

namespace Mission08_Team0315.Controllers
{
    public class HomeController : Controller
    {

        private ITaskRepository _repo;

        public HomeController(ITaskRepository temp)
        {
            _repo = temp;
        }
        public IActionResult Index()
        {




            return RedirectToAction("Quadrants");
        }
        public IActionResult Quadrants()
        {

            var Tasks = _repo.Tasks.Where(x => x.IsCompleted == false).ToList();


            return View(Tasks);
        }

        public async Task<IActionResult> Completed(int id)
        {
            // Find the task by ID
            var taskToUpdate = _repo.Tasks.FirstOrDefault(t => t.TaskId == id);

            if (taskToUpdate != null)
            {
                // Change the IsCompleted status to true
                taskToUpdate.IsCompleted = true;

                // Save the changes to the database
                _repo.SaveChanges();

                // Redirect to the 'Quadrants' view or any other appropriate action
                return RedirectToAction("Quadrants");
            }
            else
            {
                // If the task doesn't exist, return NotFound or any other appropriate response
                return NotFound();
            }
        }
        [HttpGet]
        public IActionResult AddTask()
        {


            return RedirectToAction("Form");
        }
        [HttpPost]
        public IActionResult AddTask(int id)
        {


            return RedirectToAction("Form");
        }


        [HttpGet]
        public IActionResult Form(int? id)
        {
            Task task = null; // Start with a null task.

            if (id.HasValue)
            {
                task = _repo.Tasks.FirstOrDefault(x => x.TaskId == id.Value); // Find the task with the given ID.
                if (task == null)
                {
                    // If no task was found with that ID, you might want to redirect to another page or show an error.
                    return NotFound(); // Returns a 404 error page.
                }
            }
            // If no ID is provided, 'task' remains null and will be passed to the view.

            ViewBag.categories = _repo.Categories.ToList(); // Populate the categories for the form dropdowns.

            return View(task); // Pass the task (which could be null) to the view.
        }
        [HttpPost]
        public IActionResult Form(Task task)
        {
            if (task.TaskId != 0)
            {
                if (ModelState.IsValid)
                {
                    // Check if the task exists in the database
                    var taskInDb = _repo.Tasks.FirstOrDefault(t => t.TaskId == task.TaskId);

                    if (taskInDb == null)
                    {
                        // If the task doesn't exist, return NotFound or any other appropriate response
                        return NotFound();
                    }

                    // Update the properties of the task in the database
                    taskInDb.TaskName = task.TaskName;
                    taskInDb.DueDate = task.DueDate;
                    taskInDb.Quadrant = task.Quadrant;
                    taskInDb.CategoryId = task.CategoryId;
                    taskInDb.IsCompleted = task.IsCompleted;

                    // Save the changes to the database
                    _repo.SaveChangesAsync();

                    // Redirect to the 'Quadrants' view or any other appropriate action
                    return RedirectToAction("Quadrants");
                }
                else
                {
                    ViewBag.categories = _repo.Categories.ToList();
                    return View("Form", task); // Pass the task back to the form to show validation errors
                }

            }
            else
            {
                //if taskid == 0
                var task1 = new Task
                {
                    TaskName = task.TaskName,
                    DueDate = task.DueDate,
                    Quadrant = task.Quadrant,
                    CategoryId = task.CategoryId,
                    IsCompleted = task.IsCompleted
                };

                _repo.AddTask(task1);
                _repo.SaveChanges();
                return RedirectToAction("Quadrants");
            }



            //return RedirectToAction("Quadrants");
        }


        [HttpGet]
        public IActionResult EditTask(int id)
        {
            ViewBag.task = _repo.Tasks.FirstOrDefault(x => x.TaskId == id);
            ViewBag.categories = _repo.Categories.ToList();
            return View("Form");
        }


        
        [HttpPost]
        public async Task<IActionResult> EditTask(Task taskToUpdate)
        {

            if (ModelState.IsValid)
            {
                // Check if the task exists in the database
                var taskInDb = _repo.Tasks.FirstOrDefault(t => t.TaskId == taskToUpdate.TaskId);

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
                _repo.SaveChangesAsync();

                // Redirect to the 'Quadrants' view or any other appropriate action
                return RedirectToAction("Quadrants");
            }


            return RedirectToAction("Quadrants");
        }
    }
}
