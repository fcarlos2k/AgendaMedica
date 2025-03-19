using AgendaMedica.Commands.MedicalConsultations;
using AgendaMedica.Interfaces;
using MediatR;

namespace AgendaMedica.Handlers.MedicalConsultations;

public class CancelMedicalConsultationHandler : IRequestHandler<CancelMedicalConsultationCommand, int>
{
    private readonly IMedicalConsultationRepository _repository;

    public CancelMedicalConsultationHandler(IMedicalConsultationRepository repository)
    {
        _repository = repository;
    }

    public async Task<int> Handle(CancelMedicalConsultationCommand request, CancellationToken cancellationToken)
    {
        var consultation = await _repository.GetMedicalConsultationByIdAsync(request.MedicalConsultationId);
        if (consultation != null)
        {
            consultation.MedicalConsultationStatusId = 3;
            return await _repository.UpdateMedicalConsultationAsync(consultation);
        }
        return 0;
    }
}
