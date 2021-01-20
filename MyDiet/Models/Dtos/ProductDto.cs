using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyDiet.Models.Dtos
{
    public class ProductDto
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        public ProductCategoryDto ProductCategory { get; set; }

        public IReadOnlyList<ProductCategoryDto> ProductCategories { get; set; } = new List<ProductCategoryDto>().AsReadOnly();

        public IList<MealProduct> MealProduct { get; set; } = new List<MealProduct>();
    }
}
