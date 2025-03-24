using AgendaMedica.Commands.MedicalConsultationStatuses;
using AgendaMedica.Interfaces;
using AgendaMedica.Models;
using MediatR;

namespace AgendaMedica.Handlers.MedicalConsultationStatuses;

public class UpdateMedicalConsultationStatusCommandHandler : IRequestHandler<UpdateMedicalConsultationStatusCommand, MedicalConsultationStatus>
{
    private readonly IMedicalConsultationStatusRepository _medicalConsultationStatusRepository;
    public UpdateMedicalConsultationStatusCommandHandler(IMedicalConsultationStatusRepository medicalConsultationStatusRepository)
    {
        _medicalConsultationStatusRepository = medicalConsultationStatusRepository;
    }
    public async Task<MedicalConsultationStatus> Handle(UpdateMedicalConsultationStatusCommand request, CancellationToken cancellationToken)
    {
        var medicalConsultationStatus = new MedicalConsultationStatus
        {
            Id = request.Id,
            Status = request.Status
        };
        await _medicalConsultationStatusRepository.UpdateMedicalConsultationStatusAsync(medicalConsultationStatus);
        return medicalConsultationStatus;
    }
}
