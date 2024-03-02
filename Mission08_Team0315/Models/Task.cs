using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mission08_Team0315.Models
    //Makes the task table and the fields
{
    public class Task
    {
        [Key]
        [Required]
        public int TaskId { get; set; }
        [Required]
        public string TaskName {  get; set; }
        public DateTime DueDate { get; set; }
        [Required]
        [Range(1, 4, ErrorMessage = "You must enter a valid quadrant number.")]
        public int Quadrant { get; set; }
        [ForeignKey("CategoryId")]
        public int CategoryId { get; set; }
        //public Category CategoryName { get; set; }
        public bool IsCompleted { get; set; }



    }
}
