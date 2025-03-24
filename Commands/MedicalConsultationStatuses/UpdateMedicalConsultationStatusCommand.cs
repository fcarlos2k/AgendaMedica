using AgendaMedica.Models;
using MediatR;

namespace AgendaMedica.Commands.MedicalConsultationStatuses;

public class UpdateMedicalConsultationStatusCommand : IRequest<MedicalConsultationStatus>
{
    public int Id { get; set; }
    public string? Status { get; set; }

    public UpdateMedicalConsultationStatusCommand(int id, string? status)
    {
        Id = id;
        Status = status;
    }
}
