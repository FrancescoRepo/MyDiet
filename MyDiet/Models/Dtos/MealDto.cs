using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyDiet.Models.Dtos
{
    public class MealDto
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        public IList<DietMeal> DietMeal { get; set; }

        public IList<MealProduct> MealProduct { get; set; }
    }
}
