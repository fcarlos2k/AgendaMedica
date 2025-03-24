using AgendaMedica.Models;
using MediatR;

namespace AgendaMedica.Queries.Patients;

public class GetPatientByIdQuery : IRequest<Patient>
{
    public int Id { get; set; }
    public GetPatientByIdQuery(int id)
    {
        Id = id;
    }
}
