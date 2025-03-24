using AgendaMedica.Models;
using MediatR;

namespace AgendaMedica.Queries.MedicalConsultationStatuses
{
    public class GetMedicalConsultationStatusByIdQuery :IRequest<MedicalConsultationStatus>
    {
        public int Id { get; set; }
        public GetMedicalConsultationStatusByIdQuery(int id)
        {
            Id = id;
        }
    }
}
