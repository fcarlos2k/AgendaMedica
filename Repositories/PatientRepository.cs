using AgendaMedica.Context;
using AgendaMedica.DTOs;
using AgendaMedica.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AgendaMedica.Repositories;

public class PatientRepository : IPatientRepository
{
    protected readonly AppDbContext _context;

    public PatientRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<PatientDto>> GetAllPatient()
    {
        var patientList = await _context.Patients.ToListAsync();
        return (IEnumerable<PatientDto>)patientList;
    }

    public async Task<PatientDto> GetPatientById(int id)
    {
        var patient = await _context.FindAsync<PatientDto>(id);
        if (patient is null)
        {
            throw new InvalidOperationException("Patient not found");
        }
        return patient;
    }

    public async Task<PatientDto> AddPatient(PatientDto patientDto)
    {
        if (patientDto is null)
        {
            throw new ArgumentNullException(nameof(patientDto));
        }

        await _context.AddAsync(patientDto);
        return patientDto;
    }

    public void UpdatePatient(PatientDto patientDto)
    {
        if (patientDto is null)
        {
            throw new ArgumentNullException(nameof(patientDto));
        }
        _context.Update(patientDto);
    }

    public async Task<PatientDto> DeletePatient(int id)
    {
        var patient = await GetPatientById(id);
        if (patient is null)
        {
            throw new InvalidOperationException("Patient not found");
        }
        _context.Remove(patient);
        return patient;
    }
}
