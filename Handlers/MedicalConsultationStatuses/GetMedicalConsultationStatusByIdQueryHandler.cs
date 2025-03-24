using AgendaMedica.Interfaces;
using AgendaMedica.Models;
using AgendaMedica.Queries.MedicalConsultationStatuses;
using MediatR;

namespace AgendaMedica.Handlers.MedicalConsultationStatuses;

public class GetMedicalConsultationStatusByIdQueryHandler : IRequestHandler<GetMedicalConsultationStatusByIdQuery, MedicalConsultationStatus>
{
    private readonly IMedicalConsultationStatusRepository _medicalConsultationStatusRepository;
    public GetMedicalConsultationStatusByIdQueryHandler(IMedicalConsultationStatusRepository medicalConsultationStatusRepository)
    {
        _medicalConsultationStatusRepository = medicalConsultationStatusRepository;
    }
    public async Task<MedicalConsultationStatus> Handle(GetMedicalConsultationStatusByIdQuery request, CancellationToken cancellationToken)
    {
        return await _medicalConsultationStatusRepository.GetMedicalConsultationStatusByIdAsync(request.Id);
    }
}
