using System;
using System.ComponentModel.DataAnnotations;

namespace VipeSystem.Models
{
    public class Priority
    {
        [Key]
        public int Id_Priority { get; set; }

        [Required]
        [StringLength(50)]
        public string Description { get; set; }
    }
}