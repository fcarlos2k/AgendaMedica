using AgendaMedica.Context;
using AgendaMedica.Models;
using AgendaMedica.Interfaces;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace AgendaMedica.Repositories
{
    public class PatientDapperRepository : IPatientDapperRepository
    {
        private readonly string _connectionString;

        public PatientDapperRepository(AppDbContext context)
        {
            _connectionString = context.Database.GetConnectionString();
        }

        public async Task<IEnumerable<Patient>> GetPatientsAsync()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var query = "SELECT * FROM Patient";
                //var patients = await connection.QueryAsync<Patient>(query, MapDateOnly);
                var patients = await connection.QueryAsync(query, MapDateOnly);
                return (IEnumerable<Patient>)patients;
            }
        }

        public async Task<Patient> GetPatientByIdAsync(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var query = "SELECT * FROM Patient WHERE Id = @Id";
                //var patient = await connection.QuerySingleOrDefaultAsync<Patient>(query, new { Id = id }, MapDateOnly);
                var patient = await connection.QueryAsync(query, new { Id = id });
                if (patient is null)
                {
                    throw new InvalidOperationException("Patient not found");
                }
                return (Patient)patient;
            }
        }

        public async Task<int> AddPatientAsync(Patient patient)
        {
            if (patient is null)
            {
                throw new ArgumentNullException(nameof(patient));
            }

            using (var connection = new SqlConnection(_connectionString))
            {
                var query = "INSERT INTO Patient (Name, Cpf, DateOfBirth, Phone, Address) VALUES (@Name, @Cpf, @DateOfBirth, @Phone, @Address); SELECT CAST(SCOPE_IDENTITY() as int)";
                var id = await connection.QuerySingleAsync<int>(query, patient);
                patient.Id = id;
                return id;
            }
        }

        public async Task<int> UpdatePatientAsync(Patient patient)
        {
            if (patient is null)
            {
                throw new ArgumentNullException(nameof(patient));
            }

            using (var connection = new SqlConnection(_connectionString))
            {
                var query = "UPDATE Patient SET Name = @Name, Cpf = @Cpf, DateOfBirth = @DateOfBirth, Phone = @Phone, Address = @Address WHERE Id = @Id";
                var affectedRows = await connection.ExecuteAsync(query, patient);
                return affectedRows;
            }
        }

        public async Task<int> DeletePatientAsync(int id)
        {
            var patient = await GetPatientByIdAsync(id);
            if (patient is null)
            {
                throw new InvalidOperationException("Patient not found");
            }

            using (var connection = new SqlConnection(_connectionString))
            {
                var query = "DELETE FROM Patient WHERE Id = @Id";
                var affectedRows = await connection.ExecuteAsync(query, new { Id = id });
                return affectedRows;
            }
        }

        private static Patient MapDateOnly(IDataReader reader)
        {
            return new Patient
            {
                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                Name = reader.GetString(reader.GetOrdinal("Name")),
                Cpf = reader.GetString(reader.GetOrdinal("Cpf")),
                DateOfBirth = DateOnly.FromDateTime(reader.GetDateTime(reader.GetOrdinal("DateOfBirth"))),
                Phone = reader.GetString(reader.GetOrdinal("Phone")),
                Address = reader.GetString(reader.GetOrdinal("Address"))
            };
        }
    }
}
