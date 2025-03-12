using AgendaMedica.DTOs;
using AgendaMedica.Models;
using Microsoft.AspNetCore.Mvc;

namespace AgendaMedica.Interfaces
{
    public interface IMedicalConsultationStatusDapperRepository
    {
        
        Task<ActionResult<IEnumerable<MedicalConsultationStatus>>> GetMedicalConsultationStatusAsync();
        Task<MedicalConsultationStatus> GetMedicalConsultationStatusByIdAsync(int id);
        Task<int> AddMedicalConsultationStatusAsync(MedicalConsultationStatus medicalConsultationStatus);
        Task<int> UpdateMedicalConsultationStatusAsync(MedicalConsultationStatus medicalConsultationStatus);
        Task<int> DeleteMedicalConsultationStatusAsync(int id);
    }
}
