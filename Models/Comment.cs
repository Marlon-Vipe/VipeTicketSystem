using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VipeSystem.Models
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }

        public int TicketId { get; set; }

        public int UserId { get; set; }

        [Required]
        public string Content { get; set; }
        [Column("created_at")]   // Agregar esta anotación
        public DateTime? CreatedAt { get; set; }
    }
}