using AgendaMedica.DTOs;
using MediatR;

namespace AgendaMedica.Queries.Doctor;

public class GetDoctorsQuery : IRequest<IEnumerable<DoctorDto>>
{
}
