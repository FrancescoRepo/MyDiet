using MyDiet.Business.IRepository;
using MyDiet.Models.Dtos;
using MyDiet.Services.IService;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyDiet.Services
{
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
