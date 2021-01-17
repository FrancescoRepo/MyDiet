﻿using System.ComponentModel.DataAnnotations;

namespace MyDiet.Models.Dtos
{
    public class PatientDto
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string FiscalCode { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Surname { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public int Age { get; set; }

        [Required]
        public string Gender { get; set; }

        [Required]
        public string Phone { get; set; }

        public decimal Weight { get; set; }
    }
}