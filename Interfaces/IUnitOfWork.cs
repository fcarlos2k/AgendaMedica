namespace AgendaMedica.Interfaces;

public interface IUnitOfWork
{
    IDoctorRepository DoctorRepository { get; }

    IMedicalConsultationStatusRepository MedicalConsultationStatusRepository { get; }

    IMedicalConsultationRepository MedicalConsultationRepository { get; }
    IPatientRepository PatientRepository { get; }
        
    Task CommitAsync();
}
