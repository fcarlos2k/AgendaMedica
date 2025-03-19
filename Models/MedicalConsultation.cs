using System.Text.Json.Serialization;

namespace AgendaMedica.Models;

public class MedicalConsultation
{
    public int Id { get; set; }
    public DateOnly ConsultationDate { get; set; }
    public int ConsultationTime { get; set; }
    public int DoctorId { get; set; }
    public int MedicalSpecialtyId { get; set; }
    public int PatientId { get; set; }
    public int MedicalConsultationStatusId { get; set; }


    public virtual Doctor Doctor { get; set; }
    public virtual MedicalSpecialty MedicalSpecialty { get; set; }
    public virtual Patient Patient { get; set; }
    public virtual MedicalConsultationStatus MedicalConsultationStatus { get; set; }
}