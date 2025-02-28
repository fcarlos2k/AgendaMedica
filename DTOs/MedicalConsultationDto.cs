namespace AgendaMedica.DTOs;

public class MedicalConsultationDto
{
    public int Id { get; set; }
    public DateOnly ConsultationDate { get; set; }
    public int ConsultationTime { get; set; }
    public int DoctorId { get; set; }
    public int MedicalSpecialtyId { get; set; }
    public int PatientId { get; set; }
    public int MedicalConsultationStatusId { get; set; }
}