using AgendaMedica.Context;
using AgendaMedica.Interfaces;
using AgendaMedica.Models;
using Microsoft.EntityFrameworkCore;

namespace AgendaMedica.Repository;

public class PatientRepository : IPatientRepository
{
    private readonly AppDbContext _context;

    public PatientRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Patient>> GetPatientsAsync()
    {
        return await _context.Patients
        .ToListAsync();

    }

    public async Task<Patient> GetPatientByIdAsync(int id)
    {
        var patient = await _context.Patients
            .FirstOrDefaultAsync(p => p.Id == id);
        if (patient == null)
        {
            throw new KeyNotFoundException("Patient not found");
        }
        return patient;
    }

    public async Task<int> AddPatientAsync(Patient patient)
    {
        if (patient == null)
        {
            throw new ArgumentNullException(nameof(patient));
        }

        _context.Patients.Add(patient);
        await _context.SaveChangesAsync();
        return patient.Id;
    }

    public async Task<int> UpdatePatientAsync(Patient patient)
    {
        if (patient == null)
        {
            throw new ArgumentNullException(nameof(patient));
        }
        var existingPatient = await _context.Patients.FindAsync(patient.Id);
        if (existingPatient == null)
        {
            throw new KeyNotFoundException("Patient not found");
        }
        _context.Entry(existingPatient).CurrentValues.SetValues(patient);
        return await _context.SaveChangesAsync();

    }

    public async Task<int> DeletePatientAsync(int id)
    {
        var patient = await _context.Patients.FindAsync(id);
        if (patient == null)
        {
            throw new KeyNotFoundException("Patient not found");
        }

        _context.Patients.Remove(patient);
        return await _context.SaveChangesAsync();
    }
}