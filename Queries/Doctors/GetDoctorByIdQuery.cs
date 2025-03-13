using AgendaMedica.Models;
using MediatR;

namespace AgendaMedica.Queries.Doctors;

public class GetDoctorByIdQuery : IRequest<Doctor>
{
    public int Id { get; set; }

    public GetDoctorByIdQuery(int id)
    {
        Id = id;
    }
}
