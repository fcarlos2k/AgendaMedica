using AgendaMedica.Context;
using AgendaMedica.Interfaces;
using AgendaMedica.Models;
using Microsoft.EntityFrameworkCore;

namespace AgendaMedica.Repository;

public class MedicalConsultationStatusRepository : IMedicalConsultationStatusRepository
{
    
    private readonly AppDbContext _context;

    public MedicalConsultationStatusRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<MedicalConsultationStatus>> GetMedicalConsultationStatusesAsync()
    {
        return await _context.MedicalConsultationStatuses
            .ToListAsync();
    }

    public async Task<MedicalConsultationStatus> GetMedicalConsultationStatusByIdAsync(int id)
    {
        var medicalConsultationStatus = await _context.MedicalConsultationStatuses
            .FirstOrDefaultAsync(m => m.Id == id);

        if (medicalConsultationStatus == null)
        {
            throw new KeyNotFoundException("Medical Consultation Status not found");
        }

        return medicalConsultationStatus;
    }

    public async Task<int> AddMedicalConsultationStatusAsync(MedicalConsultationStatus medicalConsultationStatus)
    {
        if (medicalConsultationStatus == null)
        {
            throw new ArgumentNullException(nameof(medicalConsultationStatus));
        }

        _context.MedicalConsultationStatuses.Add(medicalConsultationStatus);
        await _context.SaveChangesAsync();
        return medicalConsultationStatus.Id;
    }

    public async Task<int> UpdateMedicalConsultationStatusAsync(MedicalConsultationStatus medicalConsultationStatus)
    {
        if (medicalConsultationStatus == null)
        {
            throw new ArgumentNullException(nameof(medicalConsultationStatus));
        }

        var existingMedicalConsultationStatus = await _context.MedicalConsultationStatuses.FindAsync(medicalConsultationStatus.Id);
        if (existingMedicalConsultationStatus == null)
        {
            throw new KeyNotFoundException("MedicalConsultationStatus not found");
        }

        existingMedicalConsultationStatus.Status  = medicalConsultationStatus.Status;

        _context.MedicalConsultationStatuses.Update(existingMedicalConsultationStatus);
        return await _context.SaveChangesAsync();
    }

    public async Task<int> DeleteMedicalConsultationStatusAsync(int id)
    {
        var medicalConsultationStatus = await _context.MedicalConsultationStatuses.FindAsync(id);
        if (medicalConsultationStatus == null)
        {
            throw new KeyNotFoundException("MedicalConsultationStatus not found");
        }

        _context.MedicalConsultationStatuses.Remove(medicalConsultationStatus);
        return await _context.SaveChangesAsync();
    }
}