using AgendaMedica.Models;
using Microsoft.AspNetCore.Mvc;

namespace AgendaMedica.Interfaces;

public interface IDoctorDapperRepository
{
    //Task<ActionResult<Doctor>> GetDoctorsAsync(); --> video macoratti
    Task<ActionResult<IEnumerable<Doctor>>> GetDoctorsAsync();
    Task<Doctor> GetDoctorByIdAsync(int id);
    Task<int> AddDoctorAsync(Doctor doctor);
    Task<int> UpdateDoctorAsync(Doctor doctor);
    Task<int> DeleteDoctorAsync(int id);
}