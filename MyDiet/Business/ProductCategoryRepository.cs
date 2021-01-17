﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyDiet.Business.IRepository;
using MyDiet.Data;
using MyDiet.Models;
using MyDiet.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyDiet.Business
{
    public class ProductCategoryRepository : IProductCategoryRepository
    {
        private readonly ApplicationDbContext _ctx;
        private readonly IMapper _mapper;
        public ProductCategoryRepository(ApplicationDbContext ctx, IMapper mapper)
        {
            _ctx = ctx;
            _mapper = mapper;
        }

        public async Task<IList<ProductCategoryDto>> GetAllProductCategories()
        {
            return _mapper.Map<IList<ProductCategory>, IList<ProductCategoryDto>>(await _ctx.ProductCategories.ToListAsync());
        }

        public async Task<ProductCategoryDto> GetProductCategory(int id)
        {
            ProductCategory productCategory = await _ctx.ProductCategories.FindAsync(id);
            return _mapper.Map<ProductCategory, ProductCategoryDto>(productCategory);
        }

        public async Task CreateProductCategory(ProductCategoryDto productCategoryDto)
        {
            ProductCategory productCategory = _mapper.Map<ProductCategoryDto, ProductCategory>(productCategoryDto);
            await _ctx.ProductCategories.AddAsync(productCategory);
            await _ctx.SaveChangesAsync();
        }

        public async Task UpdateProductCategory(int id, ProductCategoryDto productCategoryDto)
        {
            ProductCategory productCategoryFromDb = await _ctx.ProductCategories.FindAsync(id);
            ProductCategory productCategoryToUpdate = _mapper.Map<ProductCategoryDto, ProductCategory>(productCategoryDto);
            _ctx.Entry(productCategoryFromDb).CurrentValues.SetValues(productCategoryToUpdate);
            
            await _ctx.SaveChangesAsync();
        }

        public async Task DeleteProductCategory(int id)
        {
            ProductCategory productCategoryFromDb = await _ctx.ProductCategories.FindAsync(id);
            _ctx.ProductCategories.Remove(productCategoryFromDb);

            await _ctx.SaveChangesAsync();
        }
    }
}
