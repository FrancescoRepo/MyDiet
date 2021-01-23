using MyDiet.Models.Dtos;
using System.Threading.Tasks;

namespace MyDiet.Business.IRepository
{
    public interface IMealRepository : IRepository<MealDto>
    {
        public Task<bool> AddMealToDiet(int dietId, int mealId);
        public Task<bool> AddProductToMeal(int mealId, int productId);
        public Task RemoveMealFromDiet(int dietId, int mealId);
        public Task RemoveProductFromMeal(int mealId, int productId);
    }
}
