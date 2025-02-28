using AgendaMedica.DTOs;

namespace AgendaMedica.Interfaces
{
    public interface IMedicalConsultationRepository
    {
        Task<IEnumerable<MedicalConsultationDto>> GetAllMedicalConsultation();
        Task<MedicalConsultationDto> GetDMedicalConsultationById(int id);
        Task<MedicalConsultationDto> AddMedicalConsultation(MedicalConsultationDto medicalConsultationDto);
        void UpdateMedicalConsultation(MedicalConsultationDto medicalConsultationDto);
        Task<MedicalConsultationDto> DeleteMedicalConsultation(int id);
    }
}
