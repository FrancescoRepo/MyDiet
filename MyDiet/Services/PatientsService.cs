using MyDiet.Business.IRepository;
using MyDiet.Models.Dtos;
using MyDiet.Services.IService;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyDiet.Services
{
    public class PatientsService : IPatientService
    {
        private IPatientRepository _patientRepository;

        public PatientsService(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }

        public async Task<IList<PatientDto>> GetAll()
        {
            return await _patientRepository.GetAll();
        }

        public async Task<PatientDto> Get(int id)
        {
            return await _patientRepository.Get(id);
        }

        public async Task Create(PatientDto entityDto)
        {
            await _patientRepository.Create(entityDto);
        }

        public async Task Update(int id, PatientDto entityDto)
        {
            await _patientRepository.Update(id, entityDto);
        }

        public async Task Delete(int id)
        {
            await _patientRepository.Delete(id);
        }

        public bool CheckIfUnique(string parameter, PatientDto entityDto)
        {
            return _patientRepository.CheckIfUnique(parameter, entityDto);
        }
    }
}
