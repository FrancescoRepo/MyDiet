﻿using MyDiet.Business.IRepository;
using MyDiet.Models.Dtos;
using MyDiet.Services.IService;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyDiet.Services
{
    public class DietService : IDietService
    {
        private readonly IDietRepository _dietRepository;
        public DietService(IDietRepository dietRepository)
        {
            _dietRepository = dietRepository;
        }

        public async Task<IList<DietDto>> GetAll()
        {
            return await _dietRepository.GetAll();
        }

        public async Task<DietDto> Get(int id)
        {
            return await _dietRepository.Get(id);
        }

        public async Task Create(DietDto entityDto)
        {
            await _dietRepository.Create(entityDto);
        }

        public async Task Update(int id, DietDto entityDto)
        {
            await _dietRepository.Update(id, entityDto);
        }

        public async Task Delete(int id)
        {
            await _dietRepository.Delete(id);
        }
    }
}