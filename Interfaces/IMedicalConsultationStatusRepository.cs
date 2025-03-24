using AgendaMedica.Models;

namespace AgendaMedica.Interfaces;

public interface IMedicalConsultationStatusRepository
{
    Task<IEnumerable<MedicalConsultationStatus>> GetMedicalConsultationStatusesAsync();
    Task<MedicalConsultationStatus> GetMedicalConsultationStatusByIdAsync(int id);
    Task<int> AddMedicalConsultationStatusAsync(MedicalConsultationStatus medicalConsultationStatus);
    Task<int> UpdateMedicalConsultationStatusAsync(MedicalConsultationStatus medicalConsultationStatus);
    Task<int> DeleteMedicalConsultationStatusAsync(int id);
}