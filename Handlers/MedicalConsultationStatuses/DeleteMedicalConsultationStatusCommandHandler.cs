using AgendaMedica.Commands.Doctors;
using AgendaMedica.Commands.MedicalConsultationStatus;
using AgendaMedica.Interfaces;

namespace AgendaMedica.Handlers.MedicalConsultationStatuses;

public class DeleteMedicalConsultationStatusCommandHandler
{
    private readonly IMedicalConsultationStatusDapperRepository _medicalConsultationStatusDapperRepository;

    public DeleteMedicalConsultationStatusCommandHandler(IMedicalConsultationStatusDapperRepository medicalConsultationStatusDapperRepository)
    {
        _medicalConsultationStatusDapperRepository = medicalConsultationStatusDapperRepository;
    }

    public async Task<bool> Handle(DeleteMedicalConsultationStatusCommand request, CancellationToken cancellationToken)
    {
        var result = await _medicalConsultationStatusDapperRepository.DeleteMedicalConsultationStatusAsync(request.Id);
        return result == 1;
    }
}
