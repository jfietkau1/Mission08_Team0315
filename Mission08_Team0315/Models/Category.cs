using System.ComponentModel.DataAnnotations;

namespace Mission08_Team0315.Models
    //Makes the Category Table and the fields
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}
