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

        private const string NAME_PARAMETER = "Name";

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

        public async Task AddMealToDiet(int dietId, MealDto mealDto)
        {
            //Diet dietFromDb = await _ctx.Diets.Include(d => d.DietMeal).FirstOrDefaultAsync(d => d.Id == dietId);
            DietMeal dietMeal = new DietMeal
            {
                MealId = mealDto.Id,
                DietId = dietId
            };

            await _ctx.AddAsync(dietMeal);
            await _ctx.SaveChangesAsync();
        }

        public async Task RemoveMealFromDiet(int dietId, int mealId)
        {
            DietMeal dietMeal = await _ctx.DietMeals.Where(dm => dm.DietId == dietId && dm.MealId == mealId).FirstOrDefaultAsync();
            _ctx.Remove(dietMeal);
            await _ctx.SaveChangesAsync();
        }

        public bool CheckIfUnique(string parameter, MealDto entity)
        {
            if(parameter.Equals(NAME_PARAMETER))
            {
                return _ctx.Meals.Any(m => m.Name == entity.Name);
            }

            return false;
        }
    }
}
