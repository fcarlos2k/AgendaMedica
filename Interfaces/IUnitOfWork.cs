namespace AgendaMedica.Interfaces;

public interface IUnitOfWork
{
    IDoctorDapperRepository DoctorDapperRepository { get; }
    IMedicalConsultationStatusRepository MedicalConsultationStatusRepository { get; }
    IMedicalConsultationRepository MedicalConsultationRepository { get; }
    IPatientDapperRepository PatientDapperRepository { get; }
    Task CommitAsync();
}
