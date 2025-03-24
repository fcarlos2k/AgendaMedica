using AgendaMedica.Models;
using MediatR;

namespace AgendaMedica.Queries.Doctors;

public class GetDoctorsBySpecialty : IRequest<IEnumerable<Doctor>>
{
    public int Id { get; set; }
    public GetDoctorsBySpecialty(int id)
    {
        Id = id;
    }
}