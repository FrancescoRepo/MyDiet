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
    public class DietRepository : IDietRepository
    {
        private readonly ApplicationDbContext _ctx;
        private readonly IMapper _mapper;
        private readonly IPatientRepository _patientRepository;

        public DietRepository(ApplicationDbContext ctx, IMapper mapper, IPatientRepository patientRepository)
        {
            _ctx = ctx;
            _mapper = mapper;
            _patientRepository = patientRepository;
        }

        public async Task<IList<DietDto>> GetAll()
        {
            IList<Diet> diets = await _ctx.Diets.ToListAsync();
            IList<DietDto> dietsDto = new List<DietDto>();
            foreach(Diet diet in diets)
            {
                Patient patientFromDb = await _ctx.Patients.Include(p => p.Diet).FirstOrDefaultAsync(p => p.DietId == diet.Id);
                PatientDto patientDto = _mapper.Map<Patient, PatientDto>(patientFromDb);
                DietDto dietDto = _mapper.Map<Diet, DietDto>(diet);
                dietDto.PatientDto = patientDto;
                dietsDto.Add(dietDto);
            }
            return dietsDto;
        }

        public async Task<DietDto> Get(int id)
        {
            Diet diet = await _ctx.Diets.Include(d => d.DietMeal).FirstOrDefaultAsync(d => d.Id == id);
            Patient patientFromDb = await _ctx.Patients.Include(p => p.Diet).FirstOrDefaultAsync(p => p.DietId == id);
            PatientDto patientDto = _mapper.Map<Patient, PatientDto>(patientFromDb);
            DietDto dietDto = new DietDto
            {
                PatientDto = patientDto
            };
            
            return _mapper.Map<Diet, DietDto>(diet, dietDto);
        }

        public async Task Create(DietDto entity)
        {
            Diet dietToAdd = _mapper.Map<DietDto, Diet>(entity);
            await _ctx.Diets.AddAsync(dietToAdd);
            await _ctx.SaveChangesAsync();

            entity.PatientDto.DietId = dietToAdd.Id;
            await _patientRepository.Update(entity.PatientDto.Id, entity.PatientDto);
        }

        public async Task Update(int id, DietDto entity)
        {
            Diet dietFromDb = await _ctx.Diets.FindAsync(id);
            Diet dietToUpdate = _mapper.Map<DietDto, Diet>(entity);
            _ctx.Entry(dietFromDb).CurrentValues.SetValues(dietToUpdate);
            await _ctx.SaveChangesAsync();

            await _patientRepository.DisassociateDiet(id);
            entity.PatientDto.DietId = dietToUpdate.Id;
            await _patientRepository.Update(entity.PatientDto.Id, entity.PatientDto);
        }

        public async Task Delete(int id)
        {
            Diet dietFromDb = await _ctx.Diets.FindAsync(id);
            _ctx.Diets.Remove(dietFromDb);

            await _ctx.SaveChangesAsync();
        }

        public async Task<DietDto> GetAllDietMeals(int id)
        {
            var diet = await _ctx.Diets.Include(d => d.DietMeal).ThenInclude(dm => dm.Meal).FirstOrDefaultAsync(d => d.Id == id);
            return _mapper.Map<Diet, DietDto>(diet);
        }
    }
}
