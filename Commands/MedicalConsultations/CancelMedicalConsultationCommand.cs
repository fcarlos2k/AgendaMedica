using MediatR;

namespace AgendaMedica.Commands.MedicalConsultations;

public class CancelMedicalConsultationCommand : IRequest<int>
{
    public int MedicalConsultationId { get; set; }
}
