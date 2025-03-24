using AgendaMedica.Models;
using MediatR;

namespace AgendaMedica.Queries.MedicalSpecialties;

public class GetMedicalSpecialtyByIdQuery : IRequest<MedicalSpecialty>
{
    public int Id { get; set; }
    public GetMedicalSpecialtyByIdQuery(int id)
    {
        Id = id;
    }
}
