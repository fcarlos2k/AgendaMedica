using AgendaMedica.DTOs;
using MediatR;

namespace AgendaMedica.Commands.MedicalConsultationStatus;

public class UpdateMedicalConsultationStatusCommand : IRequest<MedicalConsultationStatusDto>
{
    public int Id { get; set; }
    public string? Status { get; set; }
    public UpdateMedicalConsultationStatusCommand(int id, string? status)
    {
        Id = id;
        Status = status;
    }
}
