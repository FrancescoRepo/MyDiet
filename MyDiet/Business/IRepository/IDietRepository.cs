using MyDiet.Models;
using MyDiet.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyDiet.Business.IRepository
{
    public interface IDietRepository : IRepository<DietDto>
    {
        public Task<DietDto> GetAllDietMeals(int id);
    }
}
