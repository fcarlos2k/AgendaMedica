using AgendaMedica.Commands.MedicalConsultationStatuses;
using AgendaMedica.Interfaces;
using MediatR;

namespace AgendaMedica.Handlers.MedicalConsultationStatuses;

public class DeleteMedicalConsultationStatusCommandHandler : IRequestHandler<DeleteMedicalConsultationStatusCommand, bool>
{
    private readonly IMedicalConsultationStatusRepository _medicalConsultationStatusRepository;
    public DeleteMedicalConsultationStatusCommandHandler(IMedicalConsultationStatusRepository medicalConsultationStatusRepository)
    {
        _medicalConsultationStatusRepository = medicalConsultationStatusRepository;
    }
    public async Task<bool> Handle(DeleteMedicalConsultationStatusCommand request, CancellationToken cancellationToken)
    {
        var result = await _medicalConsultationStatusRepository.DeleteMedicalConsultationStatusAsync(request.Id);
        return result == 1;
    }
}
