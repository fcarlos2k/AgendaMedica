using AgendaMedica.Models;
using MediatR;

namespace AgendaMedica.Queries.Doctors;

public class GetDoctorsQuery : IRequest<IEnumerable<Doctor>>
{
    public string? Name { get; set; }
    public int MedicalSpecialtyId { get; set; }

    public GetDoctorsQuery(string? name = null, int medicalSpecialtyId = 0)
    {
        Name = name;
        MedicalSpecialtyId = medicalSpecialtyId;
    }
}

