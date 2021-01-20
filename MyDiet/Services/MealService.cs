using MyDiet.Business.IRepository;
using MyDiet.Models.Dtos;
using MyDiet.Services.IService;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyDiet.Services
{
    public class MealService : IMealService
    {
        private readonly IMealRepository _mealRepository;
        public MealService(IMealRepository mealRepository)
        {
            _mealRepository = mealRepository;
        }

        public async Task<IList<MealDto>> GetAll()
        {
            return await _mealRepository.GetAll();
        }

        public async Task<MealDto> Get(int id)
        {
            return await _mealRepository.Get(id);
        }
        public async Task Create(MealDto entityDto)
        {
            await _mealRepository.Create(entityDto);
        }

        public async Task Update(int id, MealDto entityDto)
        {
            await _mealRepository.Update(id, entityDto);
        }

        public async Task Delete(int id)
        {
            await _mealRepository.Delete(id);
        }

        public async Task AddMealToDiet(int dietId, MealDto mealDto)
        {
            await _mealRepository.AddMealToDiet(dietId, mealDto);
        }
        public async Task RemoveMealFromDiet(int dietId, int mealId)
        {
            await _mealRepository.RemoveMealFromDiet(dietId, mealId);
        }
    }
}
