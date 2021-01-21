using MyDiet.Business.IRepository;
using MyDiet.Models.Dtos;
using MyDiet.Services.IService;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyDiet.Services
{
    public class ProductCategoriesService : IProductCategoryService
    {
        private IProductCategoryRepository _productCategoryRepository;

        public ProductCategoriesService(IProductCategoryRepository productCategoryRepository)
        {
            _productCategoryRepository = productCategoryRepository;
        }

        public async Task<IList<ProductCategoryDto>> GetAll()
        {
            return await _productCategoryRepository.GetAll();
        }
        public async Task<ProductCategoryDto> Get(int id)
        {
            return await _productCategoryRepository.Get(id);
        }

        public async Task Create(ProductCategoryDto productCategoryDto)
        {
            await _productCategoryRepository.Create(productCategoryDto);
        }

        public async Task Update(int id, ProductCategoryDto productCategoryDto)
        {
            await _productCategoryRepository.Update(id, productCategoryDto);
        }

        public async Task Delete(int id)
        {
            await _productCategoryRepository.Delete(id);
        }

        public bool CheckIfUnique(string parameter, ProductCategoryDto entityDto)
        {
            return _productCategoryRepository.CheckIfUnique(parameter, entityDto);
        }
    }
}
