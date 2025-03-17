using AgendaMedica.Models;
using MediatR;

namespace AgendaMedica.Queries.MedicalSpecialties;

public class GetMedicalSpecialtiesQuery : IRequest<IEnumerable<MedicalSpecialty>>
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    public GetMedicalSpecialtiesQuery(string? name = null, string? description = null)
    {
        Name = name;
        Description = description;
    }
}
