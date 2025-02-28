using AgendaMedica.DTOs;

namespace AgendaMedica.Interfaces
{
    public interface IMedicalConsultationStatusRepository
    {
        Task<IEnumerable<MedicalConsultationStatusDto>> GetAllMedicalConsultationStatus();
        Task<MedicalConsultationStatusDto> GetMedicalConsultationStatusById(int id);
        Task<MedicalConsultationStatusDto> AddMedicalConsultationStatus(MedicalConsultationStatusDto medicalConsultationStatusDto);
        void UpdateMedicalConsultationStatus(MedicalConsultationStatusDto medicalConsultationStatusDto);
        Task<MedicalConsultationStatusDto> DeleteMedicalConsultationStatus(int id);
    }
}
