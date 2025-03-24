using MediatR;

namespace AgendaMedica.Commands.MedicalConsultations;

public class ScheduleMedicalConsultationCommand : IRequest<int>
{
    public int PatientId { get; set; }
    public DateOnly MedicalConsultationDate { get; set; }
    public int MedicalConsultationTime { get; set; }
    public int MedicalSpecialtyId { get; set; }
    public int DoctorId { get; set; }
}
