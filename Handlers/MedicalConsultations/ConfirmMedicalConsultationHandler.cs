using AgendaMedica.Commands.MedicalConsultations;
using AgendaMedica.Interfaces;
using MediatR;

namespace AgendaMedica.Handlers.MedicalConsultations;

public class ConfirmMedicalConsultationHandler : IRequestHandler<ConfirmMedicalConsultationCommand, int>
{
    private readonly IMedicalConsultationRepository _repository;

    public ConfirmMedicalConsultationHandler(IMedicalConsultationRepository repository)
    {
        _repository = repository;
    }

    public async Task<int> Handle(ConfirmMedicalConsultationCommand request, CancellationToken cancellationToken)
    {
        var consultation = await _repository.GetMedicalConsultationByIdAsync(request.MedicalConsultationId);
        if (consultation != null)
        {
            consultation.MedicalConsultationStatusId = 2;
            return await _repository.UpdateMedicalConsultationAsync(consultation);
        }
        return 0;
    }
}
