using AgendaMedica.Models;

namespace AgendaMedica.Interfaces;

public interface IDoctorRepository
{
    Task<IEnumerable<Doctor>> GetDoctorsAsync();
    Task<Doctor> GetDoctorByIdAsync(int id);
    Task<IEnumerable<Doctor>> GetDoctorsBySpecialtyAsync(int specialtyId);
    Task<int> AddDoctorAsync(Doctor doctor);
    Task<int> UpdateDoctorAsync(Doctor doctor);
    Task<int> DeleteDoctorAsync(int id);
}