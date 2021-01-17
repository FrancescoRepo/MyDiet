using MyDiet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyDiet.Business.IRepository
{
    public interface IPatientRepository
    {
        public Task<IList<Patient>> GetAllPatients();
        public Task<Patient> GetPatient(int id);
        public Task AddPatient(Patient patient);
        public Task UpdatePatient(int id, Patient patient);
        public Task DeletePatient(int id);
    }
}
