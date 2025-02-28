using AgendaMedica.Context;
using AgendaMedica.DTOs;
using AgendaMedica.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AgendaMedica.Repositories;

public class DoctorRepository : IDoctorRepository
{
    protected readonly AppDbContext _context;

    public DoctorRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<DoctorDto>> GetAllDoctor()
    {
        var doctorList = await _context.Doctors.ToListAsync();
        return (IEnumerable<DoctorDto>)doctorList;
    }

    public async Task<DoctorDto> GetDoctorById(int id)
    {
        var doctor = await _context.FindAsync<DoctorDto>(id);
        if (doctor is null)
        {
            throw new InvalidOperationException("Doctor not found");
        }
        return doctor;
    }

    public async Task<DoctorDto> AddDoctor(DoctorDto doctorDto)
    {
        if (doctorDto is null)
        {
            throw new ArgumentNullException(nameof(doctorDto));
        }

        await _context.AddAsync(doctorDto);
        return doctorDto;
    }

    public void UpdateDoctor(DoctorDto doctorDto)
    {
        if (doctorDto is null)
        {
            throw new ArgumentNullException(nameof(doctorDto));
        }
        _context.Update(doctorDto);
    }

    public async Task<DoctorDto> DeleteDoctor(int id)
    {
        var doctor = await GetDoctorById(id);
        if (doctor is null)
        {
            throw new InvalidOperationException("Doctor not found");
        }
        _context.Remove(doctor);
        return doctor;
    }
}
