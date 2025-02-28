using AgendaMedica.Context;
using AgendaMedica.DTOs;
using AgendaMedica.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AgendaMedica.Repositories
{
    public class MedicalConsultationStatusRepository : IMedicalConsultationStatusRepository
    {
        protected readonly AppDbContext _context;

        public MedicalConsultationStatusRepository(AppDbContext context)
        {
            _context = context;
        }


        public async Task<IEnumerable<MedicalConsultationStatusDto>> GetAllMedicalConsultationStatus()
        {
            var medicalConsultationStatusList = await _context.Doctors.ToListAsync();
            return (IEnumerable<MedicalConsultationStatusDto>)medicalConsultationStatusList;
        }

        public async Task<MedicalConsultationStatusDto> GetMedicalConsultationStatusById(int id)
        {
            var medicalConsultationStatus = await _context.FindAsync<MedicalConsultationStatusDto>(id);
            if (medicalConsultationStatus is null)
            {
                throw new InvalidOperationException("Medical Consultation Status not found");
            }
            return medicalConsultationStatus;
        }
        public async Task<MedicalConsultationStatusDto> AddMedicalConsultationStatus(MedicalConsultationStatusDto medicalConsultationStatusDto)
        {
            if (medicalConsultationStatusDto is null)
            {
                throw new ArgumentNullException(nameof(medicalConsultationStatusDto));
            }

            await _context.AddAsync(medicalConsultationStatusDto);
            return medicalConsultationStatusDto;
        }

        public void UpdateMedicalConsultationStatus(MedicalConsultationStatusDto medicalConsultationStatusDto)
        {
            if (medicalConsultationStatusDto is null)
            {
                throw new ArgumentNullException(nameof(medicalConsultationStatusDto));
            }
            _context.Update(medicalConsultationStatusDto);
        }
        public async Task<MedicalConsultationStatusDto> DeleteMedicalConsultationStatus(int id)
        {
            var medicalConsultationStatus = await GetMedicalConsultationStatusById(id);
            if (medicalConsultationStatus is null)
            {
                throw new InvalidOperationException("Medical Consultation Status not found");
            }
            _context.Remove(medicalConsultationStatus);
            return medicalConsultationStatus;
        }
    }
}
