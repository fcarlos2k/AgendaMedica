using AgendaMedica.DTOs;
using MediatR;

namespace AgendaMedica.Queries.MedicalConsultationStatuses;

public class GetMedicalConsultationStatusByIdQuery : IRequest<MedicalConsultationStatusDto>
{
    public int Id { get; set; }

    public GetMedicalConsultationStatusByIdQuery(int id)
    {
        Id = id;
    }
}

