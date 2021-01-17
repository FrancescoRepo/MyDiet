using MyDiet.Business.IRepository;
using MyDiet.Models;
using MyDiet.Models.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyDiet.Services
{
    public interface IPatientsService
    {
        public Task<IList<PatientDto>> GetAllPatients();
        public Task<PatientDto> GetPatient(int id);
        public Task CreatePatient(PatientDto patientDto);
        public Task UpdatePatient(int id, PatientDto patientDto);
        public Task DeletePatient(int id);
    }

    public class PatientsService : IPatientsService
    {
        private IPatientRepository _patientRepository;

        public PatientsService(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }

        public async Task<IList<PatientDto>> GetAllPatients()
        {
            return await _patientRepository.GetAllPatients();
        }

        public async Task<PatientDto> GetPatient(int id)
        {
            return await _patientRepository.GetPatient(id);
        }

        public async Task CreatePatient(PatientDto patientDto)
        {
            await _patientRepository.CreatePatient(patientDto);
        }

        public async Task UpdatePatient(int id, PatientDto patientDto)
        {
            await _patientRepository.UpdatePatient(id, patientDto);
        }

        public async Task DeletePatient(int id)
        {
            await _patientRepository.DeletePatient(id);
        }
    }
}
