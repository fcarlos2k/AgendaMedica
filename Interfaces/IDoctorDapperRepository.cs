using AgendaMedica.Models;

namespace AgendaMedica.Interfaces;

public interface IDoctorDapperRepository
{
    Task<IEnumerable<Doctor>> GetDoctorsAsync();
    Task<Doctor> GetDoctorByIdAsync(int id);
    Task<int> AddDoctorAsync(Doctor doctor);
    Task<int> UpdateDoctorAsync(Doctor doctor);
    Task<int> DeleteDoctorAsync(int id);
}