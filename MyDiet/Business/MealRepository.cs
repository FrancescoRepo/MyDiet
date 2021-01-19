using AutoMapper;
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
    public class MealRepository : IMealRepository
    {
        private readonly ApplicationDbContext _ctx;
        private readonly IMapper _mapper;

        public MealRepository(ApplicationDbContext ctx, IMapper mapper)
        {
            _ctx = ctx;
            _mapper = mapper;
        }
        public async Task<IList<MealDto>> GetAll()
        {
            return _mapper.Map<IList<Meal>, IList<MealDto>>(await _ctx.Meals.ToListAsync());
        }

        public async Task<MealDto> Get(int id)
        {
            Meal mealFromDb = await _ctx.Meals.FindAsync(id);
            return _mapper.Map<Meal, MealDto>(mealFromDb);
        }
        
        public async Task Create(MealDto entity)
        {
            Meal mealToAdd = _mapper.Map<MealDto, Meal>(entity);
            await _ctx.Meals.AddAsync(mealToAdd);
            await _ctx.SaveChangesAsync();
        }

        public async Task Update(int id, MealDto entity)
        {
            Meal mealFromDb = await _ctx.Meals.FindAsync(id);
            Meal mealToUpdate = _mapper.Map<MealDto, Meal>(entity);

            _ctx.Entry(mealFromDb).CurrentValues.SetValues(mealToUpdate);
            await _ctx.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            Meal mealFromDb = await _ctx.Meals.FindAsync(id);
            _ctx.Meals.Remove(mealFromDb);

            await _ctx.SaveChangesAsync();
        }
    }
}
