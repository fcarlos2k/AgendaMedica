using System.Data;
using AgendaMedica.Interfaces;
using AgendaMedica.Models;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AgendaMedica.Repositories
{
    public class DoctorDapperRepository : IDoctorDapperRepository
    {
        private readonly IDbConnection _dbConnection;

        public DoctorDapperRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        //public async Task<ActionResult<Doctor>> GetDoctorsAsync() --> video macoratti
        public async Task<ActionResult<IEnumerable<Doctor>>> GetDoctorsAsync()
        {
            string query = "SELECT * FROM Doctor";
            //var doctorList = await _dbConnection.QueryFirstOrDefaultAsync<Doctor>(query); --> video macoratti
            var doctorList = await _dbConnection.QueryAsync<Doctor>(query);
            if (doctorList is null)
            {
                throw new InvalidOperationException("Doctor not found");
            }
            //return doctorList; --> video macoratti
            return new ActionResult<IEnumerable<Doctor>>(doctorList);
        }

        public async Task<Doctor> GetDoctorByIdAsync(int id)
        {
            string query = "SELECT * FROM Doctor WHERE Id = @Id";
            var doctor = await _dbConnection.QuerySingleOrDefaultAsync<Doctor>(query, new { Id = id });
            if (doctor is null)
            {
                throw new InvalidOperationException("Doctor not found");
            }
            return doctor;

        }

        public async Task<int> AddDoctorAsync(Doctor doctor)
        {
            if (doctor is null)
            {
                throw new ArgumentNullException(nameof(doctor));
            }

            string query = "INSERT INTO Doctor (Name, MedicalSpecialtyId) VALUES (@Name, @MedicalSpecialtyId); SELECT CAST(SCOPE_IDENTITY() as int)";
            var id = await _dbConnection.QuerySingleAsync<int>(query, doctor);
            doctor.Id = id;
            return id;
        }

        public async Task<int> UpdateDoctorAsync(Doctor doctor)
        {
            if (doctor is null)
            {
                throw new ArgumentNullException(nameof(doctor));
            }

            string query = "UPDATE Doctor SET Name = @Name, MedicalSpecialtyId = @MedicalSpecialtyId WHERE Id = @Id";
            var affectedRows = await _dbConnection.ExecuteAsync(query, doctor);
            return affectedRows;

        }

        public async Task<int> DeleteDoctorAsync(int id)
        {
            var doctor = await GetDoctorByIdAsync(id);
            if (doctor is null)
            {
                throw new InvalidOperationException("Doctor not found");
            }

            var query = "DELETE FROM Doctor WHERE Id = @Id";
            var affectedRows = await _dbConnection.ExecuteAsync(query, new { Id = id });
            return affectedRows;

        }
    }
}
