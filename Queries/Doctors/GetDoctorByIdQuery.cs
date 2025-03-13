using AgendaMedica.DTOs;
using MediatR;

namespace AgendaMedica.Queries.Doctor;

public class GetDoctorByIdQuery : IRequest<DoctorDto>
{
    public int Id { get; set; }

    public GetDoctorByIdQuery(int id)
    {
        Id = id;
    }
}
