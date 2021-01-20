using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyDiet.Models.Dtos
{
    public class DietDto
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        public IReadOnlyList<PatientDto> Patients { get; set; } = new List<PatientDto>().AsReadOnly();

        public IReadOnlyList<MealDto> Meals { get; set; } = new List<MealDto>().AsReadOnly();

        public PatientDto PatientDto { get; set; }

        public IList<DietMeal> DietMeal { get; set; } = new List<DietMeal>();
    }
}
