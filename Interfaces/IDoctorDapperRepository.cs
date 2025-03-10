using AgendaMedica.Models;

namespace AgendaMedica.Interfaces;

public interface IDoctorDapperRepository
{
    Task<IEnumerable<Doctor>> GetDoctorsAsync();
    Task<Doctor> GetDoctorByIdAsync(int id);
    Task<int> AddPatientAsync(Doctor doctor);
    Task<int> UpdatePatientAsync(Doctor doctor);
    Task<int> DeletePatientAsync(int id);
}