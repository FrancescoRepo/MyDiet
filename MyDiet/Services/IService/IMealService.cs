using MyDiet.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyDiet.Services.IService
{
    public interface IMealService : IService<MealDto>
    {
        public Task<bool> AddMealToDiet(int dietId, int mealId);
        public Task<bool> AddProductToMeal(int mealId, int productId);
        public Task RemoveMealFromDiet(int dietId, int mealId);
        public Task RemoveProductFromMeal(int mealId, int productId);
    }
}
