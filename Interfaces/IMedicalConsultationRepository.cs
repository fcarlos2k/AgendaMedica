using AgendaMedica.Models;

namespace AgendaMedica.Interfaces;

public interface IMedicalConsultationRepository
{
    Task<IEnumerable<MedicalConsultation>> GetMedicalConsultationsAsync();
    Task<MedicalConsultation> GetMedicalConsultationByIdAsync(int id);
    Task<int> AddMedicalConsultationAsync(MedicalConsultation medicalConsultation);
    Task<int> UpdateMedicalConsultationAsync(MedicalConsultation medicalConsultation);
    Task<int> DeleteMedicalConsultationAsync(int id);
    Task<bool> IsDoctorAvailableAsync(int doctorId, DateOnly consultationDate, int consultationTime);
}