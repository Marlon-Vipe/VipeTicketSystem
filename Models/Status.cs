using System;
using System.ComponentModel.DataAnnotations;

namespace VipeSystem.Models
{
    public class Status
    {
        [Key]
        public int Id_Status { get; set; }

        [Required]
        [StringLength(50)]
        public string Description { get; set; }
    }
}