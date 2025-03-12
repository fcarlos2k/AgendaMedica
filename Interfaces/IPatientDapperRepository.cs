using AgendaMedica.Models;
using Microsoft.AspNetCore.Mvc;

namespace AgendaMedica.Interfaces;

public interface IPatientDapperRepository
{
    Task<ActionResult<IEnumerable<Patient>>> GetPatientsAsync();
    Task<Patient> GetPatientByIdAsync(int id);
    Task<int> AddPatientAsync(Patient patient);
    Task<int> UpdatePatientAsync(Patient patient);
    Task<int> DeletePatientAsync(int id);
}
