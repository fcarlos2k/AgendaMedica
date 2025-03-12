using AgendaMedica.Context;
using AgendaMedica.DTOs;
using AgendaMedica.Interfaces;
using AgendaMedica.Models;

namespace AgendaMedica.Repositories
{
    public class MedicalConsultationRepository : IMedicalConsultationDapperRepository
    {
        private AppDbContext context;

        public MedicalConsultationRepository(AppDbContext context)
        {
            this.context = context;
        }

        Task<MedicalConsultationDto> IMedicalConsultationDapperRepository.AddMedicalConsultation(MedicalConsultationDto medicalConsultationDto)
        {
            throw new NotImplementedException();
        }

        Task<MedicalConsultationDto> IMedicalConsultationDapperRepository.DeleteMedicalConsultation(int id)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<MedicalConsultationDto>> IMedicalConsultationDapperRepository.GetAllMedicalConsultation()
        {
            throw new NotImplementedException();
        }

        Task<MedicalConsultationDto> IMedicalConsultationDapperRepository.GetDMedicalConsultationById(int id)
        {
            throw new NotImplementedException();
        }

        void IMedicalConsultationDapperRepository.UpdateMedicalConsultation(MedicalConsultationDto medicalConsultationDto)
        {
            throw new NotImplementedException();
        }
    }
}
        