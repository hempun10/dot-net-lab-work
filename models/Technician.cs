using System.ComponentModel.DataAnnotations;

namespace myapp.models
{
    public class Technician
    {
        [Key]
        public int TechnicianId { get; set; }
        
        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }
        
        [Required]
        [StringLength(50)]
        public string LastName { get; set; }
        
        [StringLength(100)]
        public string Email { get; set; }
        
        [StringLength(20)]
        public string PhoneNumber { get; set; }
        
        [Required]
        public TechnicianSpecialty Specialty { get; set; }
        
        public bool IsAvailable { get; set; } = true;
        
        public DateTime HireDate { get; set; }
        
        // Navigation property for tickets assigned to this technician
        public virtual ICollection<HelpTicket> AssignedTickets { get; set; }
    }
    
    public enum TechnicianSpecialty
    {
        Hardware,
        Software,
        Network,
        Security,
        Database,
        GeneralSupport
    }
}