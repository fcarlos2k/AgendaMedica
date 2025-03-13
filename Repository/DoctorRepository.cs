using System.Data;
using AgendaMedica.Context;
using AgendaMedica.Interfaces;
using AgendaMedica.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AgendaMedica.Services
{
    public class DoctorRepository : IDoctorRepository
    {
        private readonly AppDbContext _context;

        public DoctorRepository(AppDbContext context)
        {
            _context = context;
        }

        Task<int> IDoctorRepository.AddDoctorAsync(Doctor doctor)
        {
            throw new NotImplementedException();
        }

        Task<int> IDoctorRepository.DeleteDoctorAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<Doctor> IDoctorRepository.GetDoctorByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        async Task<IEnumerable<Doctor>> IDoctorRepository.GetDoctorsAsync()
        {
            return await _context.Doctors
                .Include(d => d.MedicalSpecialty)
                .ToListAsync();
        }

        Task<int> IDoctorRepository.UpdateDoctorAsync(Doctor doctor)
        {
            throw new NotImplementedException();
        }
    }
}
