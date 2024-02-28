using Microsoft.EntityFrameworkCore;

namespace Mission08_Team0315.Models
{
    public class EFTaskRepository : ITaskRepository
    {
        private TaskContext _context;
        public EFTaskRepository(TaskContext temp) 
        {
            _context = temp;
        }
        public List<Task> Tasks => _context.Tasks.ToList();

        public List<Category> Categories => _context.Categories.ToList();

        public async Task<Task> GetTaskByIdAsync(int taskId)
        {
            return await _context.Tasks.FindAsync(taskId);
        }

        public async Task<IEnumerable<Task>> GetAllTasksAsync()
        {
            return await _context.Tasks.ToListAsync();
        }

        public void AddTask(Task task)
        {
            _context.Tasks.Add(task);
        }

        public void UpdateTask(Task task)
        {
            _context.Tasks.Update(task);
        }

        public void DeleteTask(int taskId)
        {
            var task = _context.Tasks.Find(taskId);
            if (task != null)
            {
                _context.Tasks.Remove(task);
            }
        }

        public async Task<Category> GetCategoryByIdAsync(int categoryId)
        {
            return await _context.Categories.FindAsync(categoryId);
        }

        public async Task<IEnumerable<Category>> GetAllCategoriesAsync()
        {
            return await _context.Categories.ToListAsync();
        }

        public void AddCategory(Category category)
        {
            _context.Categories.Add(category);
        }

        public void UpdateCategory(Category category)
        {
            _context.Categories.Update(category);
        }

        public void DeleteCategory(int categoryId)
        {
            var category = _context.Categories.Find(categoryId);
            if (category != null)
            {
                _context.Categories.Remove(category);
            }
        }

        public void SaveChangesAsync()
        {
            _context.SaveChangesAsync();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }











    }
}
