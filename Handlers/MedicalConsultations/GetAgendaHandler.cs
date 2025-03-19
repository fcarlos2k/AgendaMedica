using AgendaMedica.Interfaces;
using AgendaMedica.Queries.MedicalConsultations;
using MediatR;
using AgendaMedica.Models;

namespace AgendaMedica.Handlers.MedicalConsultations;

public class GetAgendaHandler : IRequestHandler<GetAgendaQuery, IEnumerable<MedicalConsultation>>
{
    private readonly IMedicalConsultationRepository _repository;

    public GetAgendaHandler(IMedicalConsultationRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<MedicalConsultation>> Handle(GetAgendaQuery request, CancellationToken cancellationToken)
    {
        var consultations = await _repository.GetMedicalConsultationsAsync();
        if (request.ConsultationDate.HasValue)
        {
            consultations = consultations.Where(c => c.ConsultationDate == request.ConsultationDate.Value);
        }
        if (request.MedicalSpecialtyId.HasValue)
        {
            consultations = consultations.Where(c => c.MedicalSpecialtyId == request.MedicalSpecialtyId.Value);
        }
        if (request.DoctorId.HasValue)
        {
            consultations = consultations.Where(c => c.DoctorId == request.DoctorId.Value);
        }
        if (request.StatusId.HasValue)
        {
            consultations = consultations.Where(c => c.MedicalConsultationStatusId == request.StatusId.Value);
        }
        return consultations;
    }
}
