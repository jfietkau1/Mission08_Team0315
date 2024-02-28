namespace Mission08_Team0315.Models
{
    public interface ITaskRepository
    {
        List<Task> Tasks { get; }
        List<Category> Categories { get; }

        // CRUD operations for Tasks
        Task<Task> GetTaskByIdAsync(int taskId);
        Task<IEnumerable<Task>> GetAllTasksAsync();
        void AddTask(Task task);
        void UpdateTask(Task task);
        void DeleteTask(int taskId);


        // CRUD operations for Categories (if needed)
        Task<Category> GetCategoryByIdAsync(int categoryId);
        Task<IEnumerable<Category>> GetAllCategoriesAsync();
        void AddCategory(Category category);
        void UpdateCategory(Category category);
        void DeleteCategory(int categoryId);

        // Persist changes to the database
        void SaveChangesAsync();
        void SaveChanges();

    }
}
