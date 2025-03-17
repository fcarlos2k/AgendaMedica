using AgendaMedica.Models;
using MediatR;

namespace AgendaMedica.Commands.MedicalConsultationStatuses;

public class CreateMedicalConsultationStatusCommand : IRequest<MedicalConsultationStatus>
{
    public string? Status { get; set; }
    public CreateMedicalConsultationStatusCommand(string? status)
    {
        Status = status;
    }
}
