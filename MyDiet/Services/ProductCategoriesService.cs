using MyDiet.Business.IRepository;
using MyDiet.Models.Dtos;
using MyDiet.Services.IService;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyDiet.Services
{
    public class ProductCategoriesService : IProductCategoriesService
    {
        private IProductCategoryRepository _productCategoryRepository;

        public ProductCategoriesService(IProductCategoryRepository productCategoryRepository)
        {
            _productCategoryRepository = productCategoryRepository;
        }

        public async Task<IList<ProductCategoryDto>> GetAllProductCategories()
        {
            return await _productCategoryRepository.GetAllProductCategories();
        }
        public async Task<ProductCategoryDto> GetProductCategory(int id)
        {
            return await _productCategoryRepository.GetProductCategory(id);
        }

        public async Task CreateProductCategory(ProductCategoryDto productCategoryDto)
        {
            await _productCategoryRepository.CreateProductCategory(productCategoryDto);
        }

        public async Task UpdateProductCategory(int id, ProductCategoryDto productCategoryDto)
        {
            await _productCategoryRepository.UpdateProductCategory(id, productCategoryDto);
        }

        public async Task DeleteProductCategory(int id)
        {
            await _productCategoryRepository.DeleteProductCategory(id);
        }
    }
}
