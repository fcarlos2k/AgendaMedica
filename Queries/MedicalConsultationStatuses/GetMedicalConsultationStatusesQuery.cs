using AgendaMedica.DTOs;
using MediatR;

namespace AgendaMedica.Queries.MedicalConsultationStatuses;

public class GetMedicalConsultationStatusesQuery : IRequest<IEnumerable<MedicalConsultationStatusDto>>
{
}
