using MediatR;

namespace AgendaMedica.Commands.MedicalConsultations;

public class ConfirmMedicalConsultationCommand : IRequest<int>
{
    public int MedicalConsultationId { get; set; }
}
