using System.ComponentModel.DataAnnotations;

namespace MyDiet.Models.Dtos
{
    public class ProductCategoryDto
    {
        public int Id { get; set; }

        [Required]
        public string Description { get; set; }
    }
}
