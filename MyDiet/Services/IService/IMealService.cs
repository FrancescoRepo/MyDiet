using MyDiet.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyDiet.Services.IService
{
    public interface IMealService : IService<MealDto>
    {
        public Task AddMealToDiet(int dietId, MealDto mealDto);
        public Task RemoveMealFromDiet(int dietId, int mealId);
    }
}
