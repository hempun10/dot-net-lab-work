using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace myapp.models
{
    public class HelpTicket
    {
        [Key]
        public int TicketId { get; set; }
        
        [Required]
        [StringLength(100)]
        public string Title { get; set; }
        
        [Required]
        public string Description { get; set; }
        
        [Required]
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        
        public DateTime? ResolvedDate { get; set; }
        
        [Required]
        public TicketStatus Status { get; set; } = TicketStatus.Open;
        
        [Required]
        public TicketPriority Priority { get; set; } = TicketPriority.Medium;
        
        public string RequestedBy { get; set; }
        
        [ForeignKey("Technician")]
        public int? TechnicianId { get; set; }
        public virtual Technician Technician { get; set; }
        
        // Navigation property for ticket comments
        public virtual ICollection<TicketComment> Comments { get; set; }
    }
    
    public enum TicketStatus
    {
        Open,
        InProgress,
        OnHold,
        Resolved,
        Closed
    }
    
    public enum TicketPriority
    {
        Low,
        Medium,
        High,
        Critical
    }

}