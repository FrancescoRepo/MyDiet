using MyDiet.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyDiet.Services.IService
{
    public interface IDietService : IService<DietDto>
    {
        public Task<DietDto> GetAllDietMeals(int id);
    }
}
