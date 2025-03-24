using AgendaMedica.Models;

namespace AgendaMedica.Interfaces;

public interface IMedicalSpecialtyRepository
{
    Task<IEnumerable<MedicalSpecialty>> GetMedicalSpecialtiesAsync();
    Task<MedicalSpecialty> GetMedicalSpecialtyByIdAsync(int id);
    Task<int> AddMedicalSpecialtyAsync(MedicalSpecialty medicalSpecialty);
    Task<int> UpdateMedicalSpecialtyAsync(MedicalSpecialty medicalSpecialty);
    Task<int> DeleteMedicalSpecialtyAsync(int id);
}