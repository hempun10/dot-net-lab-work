using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace myapp.models
{
   public class TicketComment
    {
        [Key]
        public int CommentId { get; set; }
        
        [Required]
        public string Content { get; set; }
        
        [Required]
        public DateTime CommentDate { get; set; } = DateTime.Now;
        
        public string CommentedBy { get; set; }
        
        [Required]
        [ForeignKey("HelpTicket")]
        public int TicketId { get; set; }
        public virtual HelpTicket HelpTicket { get; set; }
        
        public bool IsInternal { get; set; } = false;
    }
}