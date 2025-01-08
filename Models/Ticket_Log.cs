using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VipeSystem.Models
{
    public class Ticket_Log
    {
        [Key]
        public int Id_Ticket_Log { get; set; }
        [Column("ticket_id")]   // Agregar esta anotación
        public int TicketId { get; set; }
        [Column("changed_by")]   // Agregar esta anotación
        public int ChangedBy { get; set; }

        [Required]
        [StringLength(100)]
        public string Field { get; set; }
        [Column("old_value")]   // Agregar esta anotación
        public string OldValue { get; set; }
        [Column("new_value")]   // Agregar esta anotación
        public string NewValue { get; set; }
        [Column("changed_at")]   // Agregar esta anotación
        public DateTime? ChangedAt { get; set; }
    }
}