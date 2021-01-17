using MyDiet.Business.IRepository;
using MyDiet.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyDiet.Services
{
    public interface IPatientsService
    {
        public Task<IList<Patient>> GetAllPatients();
        public Task<Patient> GetPatient(int id);
        public Task AddPatient(Patient patient);
        public Task UpdatePatient(int id, Patient patient);
        public Task DeletePatient(int id);
    }

    public class PatientsService : IPatientsService
    {
        private IPatientRepository _patientRepository;

        public PatientsService(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }

        public async Task<IList<Patient>> GetAllPatients()
        {
            return await _patientRepository.GetAllPatients();
        }

        public async Task<Patient> GetPatient(int id)
        {
            return await _patientRepository.GetPatient(id);
        }

        public async Task AddPatient(Patient patient)
        {
            await _patientRepository.AddPatient(patient);
        }

        public async Task UpdatePatient(int id, Patient patient)
        {
            await _patientRepository.UpdatePatient(id, patient);
        }

        public async Task DeletePatient(int id)
        {
            await _patientRepository.DeletePatient(id);
        }
    }
}
