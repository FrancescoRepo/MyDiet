using MyDiet.Business.IRepository;
using MyDiet.Models.Dtos;
using MyDiet.Services.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyDiet.Services
{
    public class ProductService : IProductService
    {
        private IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IList<ProductDto>> GetAll()
        {
            return await _productRepository.GetAll();
        }
        public async Task<ProductDto> Get(int id)
        {
            return await _productRepository.Get(id);
        }

        public async Task Create(ProductDto entityDto)
        {
            await _productRepository.Create(entityDto);
        }

        public async Task Update(int id, ProductDto entityDto)
        {
            await _productRepository.Update(id, entityDto);
        }

        public async Task Delete(int id)
        {
            await _productRepository.Delete(id);
        }
    }
}
