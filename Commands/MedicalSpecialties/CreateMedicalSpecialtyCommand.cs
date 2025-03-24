using AgendaMedica.Models;
using MediatR;

namespace AgendaMedica.Commands.MedicalSpecialties;

public class CreateMedicalSpecialtyCommand : IRequest<MedicalSpecialty>
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    public CreateMedicalSpecialtyCommand(string? name, string? description)
    {
        Name = name;
        Description = description;
    }
}
