using System.ComponentModel.DataAnnotations;

namespace action_return_types.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public  string Description { get; set; }
        public double Price { get; set; }
    }
}
