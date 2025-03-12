using System.Data;
using AgendaMedica.Context;
using AgendaMedica.DTOs;
using AgendaMedica.Interfaces;
using AgendaMedica.Models;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AgendaMedica.Repositories
{
    public class MedicalConsultationStatusRepository : IMedicalConsultationStatusDapperRepository
    {
        private readonly IDbConnection _dbConnection;

        public MedicalConsultationStatusRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        
        public async Task<ActionResult<IEnumerable<MedicalConsultationStatus>>> GetMedicalConsultationStatusAsync()
        {
            string query = "SELECT * FROM MedicalConsultationStatus";
            
            var medicalConsultationStatusList = await _dbConnection.QueryAsync<MedicalConsultationStatus>(query);
            if (medicalConsultationStatusList is null)
            {
                throw new InvalidOperationException("Medical Consultation Status not found");
            }
            
            return new ActionResult<IEnumerable<MedicalConsultationStatus>>(medicalConsultationStatusList);
        }

        public async Task<MedicalConsultationStatus> GetMedicalConsultationStatusByIdAsync(int id)
        {
            string query = "SELECT * FROM MedicalConsultationStatus WHERE Id = @Id";
            var medicalConsultationStatus = await _dbConnection.QuerySingleOrDefaultAsync<MedicalConsultationStatus>(query, new { Id = id });
            if (medicalConsultationStatus is null)
            {
                throw new InvalidOperationException("Medical Consultation Status not found");
            }
            return medicalConsultationStatus;
        }

        public async Task<int> AddMedicalConsultationStatusAsync(MedicalConsultationStatus medicalConsultationStatus)
        {
            if (medicalConsultationStatus is null)
            {
                throw new ArgumentNullException(nameof(medicalConsultationStatus));
            }

            string query = "INSERT INTO MedicalConsultationStatus (Name, MedicalSpecialtyId) VALUES (@Name, @MedicalSpecialtyId); SELECT CAST(SCOPE_IDENTITY() as int)";
            var id = await _dbConnection.QuerySingleAsync<int>(query, medicalConsultationStatus);
            medicalConsultationStatus.Id = id;
            return id;
        }

        public async Task<int> UpdateMedicalConsultationStatusAsync(MedicalConsultationStatus medicalConsultationStatus)
        {
            if (medicalConsultationStatus is null)
            {
                throw new ArgumentNullException(nameof(medicalConsultationStatus));
            }

            string query = "UPDATE MedicalConsultationStatus SET Name = @Name, MedicalSpecialtyId = @MedicalSpecialtyId WHERE Id = @Id";
            var affectedRows = await _dbConnection.ExecuteAsync(query, medicalConsultationStatus);
            return affectedRows;
        }

        public async Task<int> DeleteMedicalConsultationStatusAsync(int id)
        {
            var medicalConsultationStatus = await GetMedicalConsultationStatusByIdAsync(id);
            if (medicalConsultationStatus is null)
            {
                throw new InvalidOperationException("Medical Consultation Status not found");
            }

            var query = "DELETE FROM MedicalConsultationStatus WHERE Id = @Id";
            var affectedRows = await _dbConnection.ExecuteAsync(query, new { Id = id });
            return affectedRows;
        }
    }
}
