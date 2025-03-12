using AgendaMedica.Context;
using AgendaMedica.Models;
using AgendaMedica.Interfaces;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace AgendaMedica.Repositories
{
    public class DoctorDapperRepository : IDoctorDapperRepository
    {
        private readonly IDbConnection _dbConnection;

        public DoctorDapperRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<IEnumerable<Doctor>> GetDoctorsAsync()
        {
            using (var connection = new SqlConnection(_dbConnection))
            {
                var query = "SELECT * FROM Doctor";
                var doctorList = await connection.QueryAsync<Doctor>(query);
                return doctorList;
            }
        }

        public async Task<Doctor> GetDoctorByIdAsync(int id)
        {
            using (var connection = new SqlConnection(_dbConnection))
            {
                var query = "SELECT * FROM Doctor WHERE Id = @Id";
                var doctor = await connection.QuerySingleOrDefaultAsync<Doctor>(query, new { Id = id });
                if (doctor is null)
                {
                    throw new InvalidOperationException("Doctor not found");
                }
                return doctor;
            }
        }

        public async Task<int> AddDoctorAsync(Doctor doctor)
        {
            if (doctor is null)
            {
                throw new ArgumentNullException(nameof(doctor));
            }

            using (var connection = new SqlConnection(_dbConnection))
            {
                var query = "INSERT INTO Doctor (Name, MedicalSpecialtyId) VALUES (@Name, @MedicalSpecialtyId); SELECT CAST(SCOPE_IDENTITY() as int)";
                var id = await connection.QuerySingleAsync<int>(query, doctor);
                doctor.Id = id;
                return id;
            }
        }

        public async Task<int> UpdateDoctorAsync(Doctor doctor)
        {
            if (doctor is null)
            {
                throw new ArgumentNullException(nameof(doctor));
            }

            using (var connection = new SqlConnection(_dbConnection))
            {
                var query = "UPDATE Doctor SET Name = @Name, MedicalSpecialtyId = @MedicalSpecialtyId WHERE Id = @Id";
                var affectedRows = await connection.ExecuteAsync(query, doctor);
                return affectedRows;
            }
        }

        public async Task<int> DeleteDoctorAsync(int id)
        {
            var doctor = await GetDoctorByIdAsync(id);
            if (doctor is null)
            {
                throw new InvalidOperationException("Doctor not found");
            }

            using (var connection = new SqlConnection(_dbConnection))
            {
                var query = "DELETE FROM Doctor WHERE Id = @Id";
                var affectedRows = await connection.ExecuteAsync(query, new { Id = id });
                return affectedRows;
            }
        }
    }
}
