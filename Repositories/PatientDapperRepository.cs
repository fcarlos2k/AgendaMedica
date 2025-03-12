using AgendaMedica.Context;
using AgendaMedica.Models;
using AgendaMedica.Interfaces;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;
using Microsoft.AspNetCore.Mvc;
using System.Data.Common;

namespace AgendaMedica.Repositories
{
    public class PatientDapperRepository : IPatientDapperRepository
    {
        private readonly IDbConnection _dbConnection;

        public PatientDapperRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<ActionResult<IEnumerable<Patient>>> GetPatientsAsync()
        {
            string query = "SELECT * FROM Patient";
            var patientList = await _dbConnection.QueryAsync<Patient>(query);
            if (patientList is null)
            {
                throw new InvalidOperationException("Patient not found");
            }
            return new ActionResult<IEnumerable<Patient>>(patientList);
        }

        public async Task<Patient> GetPatientByIdAsync(int id)
        {
            string query = "SELECT * FROM Patient WHERE Id = @Id";
            var patient = await _dbConnection.QuerySingleOrDefaultAsync<Patient>(query, new { Id = id });
            if (patient is null)
            {
                throw new InvalidOperationException("Patient not found");
            }
            return patient;
        }

        public async Task<int> AddPatientAsync(Patient patient)
        {
            if (patient is null)
            {
                throw new ArgumentNullException(nameof(patient));
            }

            string query = "INSERT INTO Patient (Name, Cpf, DateOfBirth, Phone, Address) VALUES (@Name, @Cpf, @DateOfBirth, @Phone, @Address); SELECT CAST(SCOPE_IDENTITY() as int)";
            var id = await _dbConnection.QuerySingleAsync<int>(query, patient);
            patient.Id = id;
            return id;
        }

        public async Task<int> UpdatePatientAsync(Patient patient)
        {
            if (patient is null)
            {
                throw new ArgumentNullException(nameof(patient));
            }

            string query = "UPDATE Patient SET Name = @Name, Cpf = @Cpf, DateOfBirth = @DateOfBirth, Phone = @Phone, Address = @Address WHERE Id = @Id";
            var affectedRows = await _dbConnection.ExecuteAsync(query, patient);
            return affectedRows;
        }

        public async Task<int> DeletePatientAsync(int id)
        {
            var patient = await GetPatientByIdAsync(id);
            if (patient is null)
            {
                throw new InvalidOperationException("Patient not found");
            }

            var query = "DELETE FROM Patient WHERE Id = @Id";
            var affectedRows = await _dbConnection.ExecuteAsync(query, new { Id = id });
            return affectedRows;
        }
    }
}
