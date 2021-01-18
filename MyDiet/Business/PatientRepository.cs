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
    public class PatientRepository : IPatientRepository
    {
        private readonly ApplicationDbContext _ctx;
        private readonly IMapper _mapper;

        public PatientRepository(ApplicationDbContext ctx, IMapper mapper)
        {
            _ctx = ctx;
            _mapper = mapper;
        }

        public async Task<IList<PatientDto>> GetAll()
        {
            return _mapper.Map<IList<Patient>, IList<PatientDto>>(await _ctx.Patients.ToListAsync());
        }

        public async Task<PatientDto> Get(int id)
        {
            Patient patient = await _ctx.Patients.FindAsync(id);
            Weight patientWeight = await _ctx.Weights.FirstOrDefaultAsync(w => w.PatientId == patient.Id);
            patient.Weight = patientWeight.WeightValue;

            return _mapper.Map<Patient, PatientDto>(patient);
        }

        public async Task Create(PatientDto patientDto)
        {
            Patient patient = _mapper.Map<PatientDto, Patient>(patientDto);
            await _ctx.Patients.AddAsync(patient);
            await _ctx.SaveChangesAsync();

            await _ctx.Weights.AddAsync(new Weight
            {
                PatientId = patient.Id,
                Date = DateTime.Now,
                WeightValue = patient.Weight
            });

            await _ctx.SaveChangesAsync();
        }

        public async Task Update(int id, PatientDto patientDto)
        {
            Patient patientFromDb = await _ctx.Patients.FindAsync(id);
            Patient patientToUpdate = _mapper.Map<PatientDto, Patient>(patientDto, patientFromDb);
            _ctx.Entry(patientFromDb).CurrentValues.SetValues(patientToUpdate);

            await _ctx.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            Patient patient = await _ctx.Patients.FindAsync(id);
            _ctx.Patients.Remove(patient);

            await _ctx.SaveChangesAsync();
        }
    }
}
