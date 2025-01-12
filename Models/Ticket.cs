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

        [Column("created_by")]
        public int CreatedBy { get; set; }

        [Column("assigned_to")]
        public int? AssignedTo { get; set; }  // Clave foránea de User

        [Column("category_id")]
        public int? CategoryId { get; set; }  // Clave foránea de Category

        [Column("created_at")]
        public DateTime? CreatedAt { get; set; }

        [Column("updated_at")]
        public DateTime? UpdatedAt { get; set; }

        // Propiedades de navegación (sin mapeo a columnas)
        public virtual User AssignedToNavigation { get; set; }  // Relación con User
        public virtual Category CategoryIdNavigation { get; set; }  // Relación con Category
    }
}

