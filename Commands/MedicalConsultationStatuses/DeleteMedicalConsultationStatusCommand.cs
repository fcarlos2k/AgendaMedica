using MediatR;

namespace AgendaMedica.Commands.MedicalConsultationStatuses;

public class DeleteMedicalConsultationStatusCommand : IRequest<bool>
{
    public int Id { get; set; }
    public DeleteMedicalConsultationStatusCommand(int id)
    {
        Id = id;
    }
}
