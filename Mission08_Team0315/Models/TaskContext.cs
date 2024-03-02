using Microsoft.EntityFrameworkCore;

namespace Mission08_Team0315.Models
    //These set up the tables for the HomeController to usw
{
    public class TaskContext : DbContext
    {
        public TaskContext(DbContextOptions<TaskContext> options) : base(options) { }

        public DbSet<Task> Tasks { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId=1, CategoryName = "Home"},
                new Category { CategoryId=2, CategoryName="School"},
                new Category { CategoryId=3, CategoryName="Work"},
                new Category { CategoryId=4, CategoryName="Church"}
                );
        }
    }
}
