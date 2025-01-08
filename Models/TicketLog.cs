using System;
using System.ComponentModel.DataAnnotations;

namespace VipeSystem.Models
{
    public class TicketLog
    {
        [Key]
        public int Id_Ticket_Log { get; set; }

        public int TicketId { get; set; }

        public int ChangedBy { get; set; }

        [Required]
        [StringLength(100)]
        public string Field { get; set; }

        public string OldValue { get; set; }

        public string NewValue { get; set; }

        public DateTime? ChangedAt { get; set; }
    }
}