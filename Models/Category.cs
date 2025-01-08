﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VipeSystem.Models
{
    public class Category
    {
        [Key]
        public int Id_Category { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [StringLength(50)]
        public string Description { get; set; }
        [Column("created_at")]   // Agregar esta anotación
        public DateTime? CreatedAt { get; set; }
    }
}