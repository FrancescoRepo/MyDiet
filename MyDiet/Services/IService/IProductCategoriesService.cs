using MyDiet.Models.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyDiet.Services.IService
{
    public interface IProductCategoriesService
    {
        public Task<IList<ProductCategoryDto>> GetAllProductCategories();
        public Task<ProductCategoryDto> GetProductCategory(int id);
        public Task CreateProductCategory(ProductCategoryDto productCategoryDto);
        public Task UpdateProductCategory(int id, ProductCategoryDto productCategoryDto);
        public Task DeleteProductCategory(int id);
    }
}
