using Microsoft.EntityFrameworkCore;
using MyDiet.Business.IRepository;
using MyDiet.Data;
using MyDiet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyDiet.Business
{
    public class PatientRepository : IPatientRepository
    {
        private readonly ApplicationDbContext _ctx;
        public PatientRepository(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<IList<Patient>> GetAllPatients()
        {
            return await _ctx.Patients.ToListAsync();
        }

        public async Task<Patient> GetPatient(int id)
        {
            return await _ctx.Patients.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task AddPatient(Patient patient)
        {
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

        public async Task UpdatePatient(int id, Patient patient)
        {
            _ctx.Patients.Update(patient);
            await _ctx.SaveChangesAsync();
        }

        public async Task DeletePatient(int id)
        {
            Patient patient = await _ctx.Patients.FirstOrDefaultAsync(p => p.Id == id);
            _ctx.Patients.Remove(patient);
            await _ctx.SaveChangesAsync();
        }
    }
}
