using MyDiet.Models.Dtos;
using MyDiet.Services.IService;
using System.ComponentModel.DataAnnotations;

namespace MyDiet.Utils
{
    public class UniqueFieldValidator : ValidationAttribute
    {
        public string ErrorMessage { get; set; }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
             if(validationContext.ObjectInstance is ProductCategoryDto)
            {
                IProductCategoryService productCategoryService = validationContext.GetService(typeof(IProductCategoryService)) as IProductCategoryService;
                ProductCategoryDto dto = validationContext.ObjectInstance as ProductCategoryDto;

                string parameter = validationContext.MemberName;
                bool isUnique = productCategoryService.CheckIfUnique(parameter, dto);

                return isUnique ? null : new ValidationResult(ErrorMessage);
            }
            
            return null;
        }
    }
}
