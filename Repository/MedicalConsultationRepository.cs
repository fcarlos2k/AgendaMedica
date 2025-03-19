using AgendaMedica.Context;
using AgendaMedica.Interfaces;
using AgendaMedica.Models;
using Microsoft.EntityFrameworkCore;

namespace AgendaMedica.Repository;

public class MedicalConsultationRepository : IMedicalConsultationRepository
{
    private readonly AppDbContext _context;
    public MedicalConsultationRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<MedicalConsultation>> GetMedicalConsultationsAsync()
    {
        return await _context.MedicalConsultations.ToListAsync();
    }

    public async Task<MedicalConsultation> GetMedicalConsultationByIdAsync(int id)
    {
        return await _context.MedicalConsultations.FindAsync(id);
    }

    public async Task<bool> IsDoctorAvailableAsync(int doctorId, DateOnly date, int time)
    {
        return !await _context.MedicalConsultations
            .AnyAsync(c => c.DoctorId == doctorId && c.ConsultationDate == date && c.ConsultationTime == time);
    }

    public async Task<int> AddMedicalConsultationAsync(MedicalConsultation medicalConsultation)
    {
        _context.MedicalConsultations.Add(medicalConsultation);
        return await _context.SaveChangesAsync();
    }

    public async Task<int> UpdateMedicalConsultationAsync(MedicalConsultation medicalConsultation)
    {
        _context.MedicalConsultations.Update(medicalConsultation);
        return await _context.SaveChangesAsync();
    }

    public async Task<int> DeleteMedicalConsultationAsync(int id)
    {
        var consultation = await _context.MedicalConsultations.FindAsync(id);
        if (consultation != null)
        {
            _context.MedicalConsultations.Remove(consultation);
            return await _context.SaveChangesAsync();
        }
        return 0;
    }

   
}
