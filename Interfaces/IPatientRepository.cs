using AgendaMedica.DTOs;

namespace AgendaMedica.Interfaces
{
    public interface IPatientRepository
    {
        Task<IEnumerable<PatientDto>> GetAllPatient();
        Task<PatientDto> GetPatientById(int id);
        Task<PatientDto> AddPatient(PatientDto patientDto);
        void UpdatePatient(PatientDto patientDto);
        Task<PatientDto> DeletePatient(int id);
    }
}
