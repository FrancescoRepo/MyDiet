﻿using MyDiet.Business.IRepository;
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

        public async Task<bool> AddMealToDiet(int dietId, int mealId)
        {
            return await _mealRepository.AddMealToDiet(dietId, mealId);
        }

        public async Task RemoveMealFromDiet(int dietId, int mealId)
        {
            await _mealRepository.RemoveMealFromDiet(dietId, mealId);
        }

        public bool CheckIfUnique(string parameter, MealDto entityDto)
        {
            return _mealRepository.CheckIfUnique(parameter, entityDto);
        }

        public async Task<bool> AddProductToMeal(int mealId, int productId)
        {
            return await _mealRepository.AddProductToMeal(mealId, productId);
        }

        public async Task RemoveProductFromMeal(int mealId, int productId)
        {
            await _mealRepository.RemoveProductFromMeal(mealId, productId);
        }
    }
}
