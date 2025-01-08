using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VipeSystem.Models
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }
        [Column("ticket_id")]   // Agregar esta anotación
        public int TicketId { get; set; }
        [Column("user_id")]   // Agregar esta anotación
        public int UserId { get; set; }

        [Required]
        public string Content { get; set; }
        [Column("created_at")]   // Agregar esta anotación
        public DateTime? CreatedAt { get; set; }
    }
}