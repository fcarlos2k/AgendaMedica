using Microsoft.EntityFrameworkCore;
using AgendaMedica.Context;
using AgendaMedica.Interfaces;
using AgendaMedica.Models;

namespace AgendaMedica.Repository;

public class MedicalSpecialtyRepository : IMedicalSpecialtyRepository
{
    private readonly AppDbContext _context;
    public MedicalSpecialtyRepository(AppDbContext context)
    {
        _context = context;
    }
    public async Task<IEnumerable<MedicalSpecialty>> GetMedicalSpecialtiesAsync()
    {
        return await _context.MedicalSpecialties
        .ToListAsync();
    }
    public async Task<MedicalSpecialty> GetMedicalSpecialtyByIdAsync(int id)
    {
        var medicalSpecialty = await _context.MedicalSpecialties
            .FirstOrDefaultAsync(p => p.Id == id);
        if (medicalSpecialty == null)
        {
            throw new KeyNotFoundException("Medical Specialty not found");
        }
        return medicalSpecialty;
    }
    public async Task<int> AddMedicalSpecialtyAsync(MedicalSpecialty medicalSpecialty)
    {
        if (medicalSpecialty == null)
        {
            throw new ArgumentNullException(nameof(medicalSpecialty));
        }
        _context.MedicalSpecialties.Add(medicalSpecialty);
        await _context.SaveChangesAsync();
        return medicalSpecialty.Id;
    }
    public async Task<int> UpdateMedicalSpecialtyAsync(MedicalSpecialty medicalSpecialty)
    {
        if (medicalSpecialty == null)
        {
            throw new ArgumentNullException(nameof(medicalSpecialty));
        }
        var existingMedicalSpecialty = await _context.MedicalSpecialties.FindAsync(medicalSpecialty.Id);
        if (existingMedicalSpecialty == null)
        {
            throw new KeyNotFoundException("Medical Specialty not found");
        }
        _context.Entry(existingMedicalSpecialty).CurrentValues.SetValues(medicalSpecialty);
        return await _context.SaveChangesAsync();
    }
    public async Task<int> DeleteMedicalSpecialtyAsync(int id)
    {
        var medicalSpecialty = await _context.MedicalSpecialties.FindAsync(id);
        if (medicalSpecialty == null)
        {
            throw new KeyNotFoundException("Medical Specialty not found");
        }
        _context.MedicalSpecialties.Remove(medicalSpecialty);
        return await _context.SaveChangesAsync();
    }
}
