using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;

namespace VipeSystem.Models
{
    public class User
    {
        [Key]
        public int Id_User { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        [StringLength(100)]
        public string Email { get; set; }
        [Required]
        [StringLength(255)]
        public string Password { get; set; }
        [Column("created_at")]  // Agregar esta anotación
        public DateTime? CreatedAt { get; set; }
        [Column("modify_at")]   // Agregar esta anotación
        public DateTime? ModifyAt { get; set; }
    }
}