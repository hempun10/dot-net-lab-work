using System.ComponentModel.DataAnnotations;

namespace myapp.models
{
    public class Hotel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Address { get; set; }

        
    }
}