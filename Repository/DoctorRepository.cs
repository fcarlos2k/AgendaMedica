using System.Collections.Generic;
using System.Threading.Tasks;
using AgendaMedica.Context;
using AgendaMedica.Interfaces;
using AgendaMedica.Models;
using Microsoft.EntityFrameworkCore;

namespace AgendaMedica.Repositories
{
    public class DoctorRepository : IDoctorRepository
    {
        private readonly AppDbContext _context;

        public DoctorRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Doctor>> GetDoctorsAsync()
        {
            return await _context.Doctors
                .Include(d => d.MedicalSpecialty)
                .ToListAsync();
        }

        public async Task<Doctor> GetDoctorByIdAsync(int id)
        {
            var doctor = await _context.Doctors
                .Include(d => d.MedicalSpecialty)
                .FirstOrDefaultAsync(d => d.Id == id);

            if (doctor == null)
            {
                throw new KeyNotFoundException("Doctor not found");
            }

            return doctor;
        }

        public async Task<int> AddDoctorAsync(Doctor doctor)
        {
            if (doctor == null)
            {
                throw new ArgumentNullException(nameof(doctor));
            }

            _context.Doctors.Add(doctor);
            await _context.SaveChangesAsync();
            return doctor.Id;
        }

        public async Task<int> UpdateDoctorAsync(Doctor doctor)
        {
            if (doctor == null)
            {
                throw new ArgumentNullException(nameof(doctor));
            }

            var existingDoctor = await _context.Doctors.FindAsync(doctor.Id);
            if (existingDoctor == null)
            {
                throw new KeyNotFoundException("Doctor not found");
            }

            existingDoctor.Name = doctor.Name;
            existingDoctor.MedicalSpecialtyId = doctor.MedicalSpecialtyId;

            _context.Doctors.Update(existingDoctor);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> DeleteDoctorAsync(int id)
        {
            var doctor = await _context.Doctors.FindAsync(id);
            if (doctor == null)
            {
                throw new KeyNotFoundException("Doctor not found");
            }

            _context.Doctors.Remove(doctor);
            return await _context.SaveChangesAsync();
        }
    }
}
