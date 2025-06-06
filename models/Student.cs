using System.ComponentModel.DataAnnotations;

namespace myapp.models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Gender { get; set; }

        [Required]
        public int ClassId { get; set; }

        public Class Class { get; set; }
    }
}