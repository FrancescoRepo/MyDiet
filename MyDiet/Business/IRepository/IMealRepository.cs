using MyDiet.Models.Dtos;
using System.Threading.Tasks;

namespace MyDiet.Business.IRepository
{
    public interface IMealRepository : IRepository<MealDto>
    {
        public Task AddMealToDiet(int dietId, int mealId);
        public Task RemoveMealFromDiet(int dietId, int mealId);
    }
}
