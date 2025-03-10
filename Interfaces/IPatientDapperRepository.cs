using AgendaMedica.Models;

namespace AgendaMedica.Interfaces;

public interface IPatientDapperRepository
{
    Task<IEnumerable<Patient>> GetPatientsAsync();
    Task<Patient> GetPatientByIdAsync(int id);
    Task<int> AddPatientAsync(Patient patient);
    Task<int> UpdatePatientAsync(Patient patient);
    Task<int> DeletePatientAsync(int id);
}
