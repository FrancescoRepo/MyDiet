﻿using System.ComponentModel.DataAnnotations;

namespace MyDiet.Models.Dtos
{
    public class PatientDto
    {
        public int Id { get; set; }

        [Required]
        public string FiscalCode { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Surname { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public int Age { get; set; }

        [Required]
        public string Gender { get; set; }

        [Required]
        public string Phone { get; set; }

        public decimal Weight { get; set; }

        public int? DietId { get; set; }
    }
}
