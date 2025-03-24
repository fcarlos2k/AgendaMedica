using AgendaMedica.Models;
using MediatR;

namespace AgendaMedica.Queries.MedicalConsultationStatuses
{
    public class GetMedicalConsultationStatusesQuery : IRequest<IEnumerable<MedicalConsultationStatus>>
    {
        public string? Name { get; set; }
        public GetMedicalConsultationStatusesQuery(string? name = null)
        {
            Name = name;
        }
    }
}
