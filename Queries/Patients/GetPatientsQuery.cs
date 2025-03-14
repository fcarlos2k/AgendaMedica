using AgendaMedica.Models;
using MediatR;

namespace AgendaMedica.Queries.Patients;

public class GetPatientsQuery : IRequest<IEnumerable<Patient>>
{
    public string? Name { get; set; }
    public string? Cpf { get; set; }
    public DateTime? DateOfBirth { get; set; }
    public string? Phone { get; set; }
    public string? Address { get; set; }

    public GetPatientsQuery(string? name = null, string? cpf = null, DateTime? dateOfBirth = null, string? phone = null, string? address = null)
    {
        Name = name;
        Cpf = cpf;
        DateOfBirth = dateOfBirth;
        Phone = phone;
        Address = address;
    }
}
