namespace AgendaMedica.Interfaces;

public interface IUnitOfWork
{
    IDoctorDapperRepository DoctorDapperRepository { get; }
    IMedicalConsultationStatusDapperRepository MedicalConsultationStatusRepository { get; }
    IMedicalConsultationDapperRepository MedicalConsultationRepository { get; }
    IPatientDapperRepository PatientDapperRepository { get; }
    Task CommitAsync();
}
