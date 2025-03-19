using System.Text.Json.Serialization;
using AgendaMedica.Models;
using MediatR;

namespace AgendaMedica.Queries.MedicalConsultations;

public class GetAgendaQuery : IRequest<IEnumerable<MedicalConsultation>>
{
    public DateOnly? ConsultationDate { get; set; }
    public int? MedicalSpecialtyId { get; set; }
    public int? DoctorId { get; set; }
    public int? StatusId { get; set; }
}
