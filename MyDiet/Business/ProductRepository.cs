using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyDiet.Business.IRepository;
using MyDiet.Data;
using MyDiet.Models;
using MyDiet.Models.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyDiet.Business
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _ctx;
        private readonly IMapper _mapper;

        public ProductRepository(ApplicationDbContext ctx, IMapper mapper)
        {
            _ctx = ctx;
            _mapper = mapper;
        }

        public async Task<IList<ProductDto>> GetAll()
        {
            return _mapper.Map<IList<Product>, IList<ProductDto>>(await _ctx.Products.Include(p => p.ProductCategory).ToListAsync());
        }

        public async Task<ProductDto> Get(int id)
        {
            Product productFromDb = await _ctx.Products.Include(p => p.ProductCategory).FirstOrDefaultAsync(p => p.Id == id);
            ProductDto productDto = _mapper.Map<Product, ProductDto>(productFromDb);
            productDto.ProductCategories = (IReadOnlyList<ProductCategoryDto>)_mapper.Map<IList<ProductCategory>, IList<ProductCategoryDto>>(await _ctx.ProductCategories.ToListAsync());

            return productDto;
        }

        public async Task Create(ProductDto entity)
        {
            Product productToAdd = _mapper.Map<ProductDto, Product>(entity);
            productToAdd.ProductCategory = null;
            await _ctx.Products.AddAsync(productToAdd);

            await _ctx.SaveChangesAsync();
        }

        public async Task Update(int id, ProductDto entity)
        {
            Product productFromDb = await _ctx.Products.Include(p => p.ProductCategory).FirstOrDefaultAsync(p => p.Id == id);
            Product productToUpdate = _mapper.Map<ProductDto, Product>(entity);
            _ctx.Entry(productFromDb).CurrentValues.SetValues(productToUpdate);

            await _ctx.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            Product productFromDb = await _ctx.Products.Include(p => p.ProductCategory).FirstOrDefaultAsync(p => p.Id == id);
            _ctx.Products.Remove(productFromDb);

            await _ctx.SaveChangesAsync();
        }
    }
}
