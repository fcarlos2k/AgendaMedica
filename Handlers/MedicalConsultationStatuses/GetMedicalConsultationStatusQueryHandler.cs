using AgendaMedica.Interfaces;
using AgendaMedica.Models;
using AgendaMedica.Queries.MedicalConsultationStatuses;
using MediatR;

namespace AgendaMedica.Handlers.MedicalConsultationStatuses;

public class GetMedicalConsultationStatusesQueryHandler : IRequestHandler<GetMedicalConsultationStatusesQuery, IEnumerable<MedicalConsultationStatus>>
{
    private readonly IMedicalConsultationStatusRepository _medicalConsultationStatusRepository;
    public GetMedicalConsultationStatusesQueryHandler(IMedicalConsultationStatusRepository medicalConsultationStatusRepository)
    {
        _medicalConsultationStatusRepository = medicalConsultationStatusRepository;
    }
    public async Task<IEnumerable<MedicalConsultationStatus>> Handle(GetMedicalConsultationStatusesQuery request, CancellationToken cancellationToken)
    {
        return await _medicalConsultationStatusRepository.GetMedicalConsultationStatusesAsync();
    }
}
