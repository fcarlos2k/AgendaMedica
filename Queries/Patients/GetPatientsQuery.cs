using AgendaMedica.DTOs;
using MediatR;

namespace AgendaMedica.Queries.Patients;

public class GetPatientsQuery : IRequest<IEnumerable<PatientDto>>
{
}
