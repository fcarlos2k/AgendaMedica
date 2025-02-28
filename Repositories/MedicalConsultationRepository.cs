using AgendaMedica.Context;
using AgendaMedica.DTOs;
using AgendaMedica.Interfaces;
using AgendaMedica.Models;

namespace AgendaMedica.Repositories
{
    public class MedicalConsultationRepository : IMedicalConsultationRepository
    {
        private AppDbContext context;

        public MedicalConsultationRepository(AppDbContext context)
        {
            this.context = context;
        }

        Task<MedicalConsultationDto> IMedicalConsultationRepository.AddMedicalConsultation(MedicalConsultationDto medicalConsultationDto)
        {
            throw new NotImplementedException();
        }

        Task<MedicalConsultationDto> IMedicalConsultationRepository.DeleteMedicalConsultation(int id)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<MedicalConsultationDto>> IMedicalConsultationRepository.GetAllMedicalConsultation()
        {
            throw new NotImplementedException();
        }

        Task<MedicalConsultationDto> IMedicalConsultationRepository.GetDMedicalConsultationById(int id)
        {
            throw new NotImplementedException();
        }

        void IMedicalConsultationRepository.UpdateMedicalConsultation(MedicalConsultationDto medicalConsultationDto)
        {
            throw new NotImplementedException();
        }
    }
}
        