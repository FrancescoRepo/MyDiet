﻿using MyDiet.Models.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyDiet.Business.IRepository
{
    public interface IPatientRepository
    {
        public Task<IList<PatientDto>> GetAllPatients();
        public Task<PatientDto> GetPatient(int id);
        public Task CreatePatient(PatientDto patientDto);
        public Task UpdatePatient(int id, PatientDto patientDto);
        public Task DeletePatient(int id);
    }
}
