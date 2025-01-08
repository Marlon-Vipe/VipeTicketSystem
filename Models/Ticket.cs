using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VipeSystem.Models
{
    public class Ticket
    {
        [Key]
        public int Id_Ticket { get; set; }

        [Required]
        [StringLength(255)]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        public int Status { get; set; }

        public int Priority { get; set; }
        [Column("created_by")]  // Agregar esta anotación
        public int CreatedBy { get; set; }
        [Column("assigned_to")]  // Agregar esta anotación
        public int? AssignedTo { get; set; }
        [Column("category_id")]  // Agregar esta anotación
        public int? CategoryId { get; set; }
        [Column("created_at")]  // Agregar esta anotación
        public DateTime? CreatedAt { get; set; }
        [Column("updated_at")]  // Agregar esta anotación
        public DateTime? UpdatedAt { get; set; }
    }
}