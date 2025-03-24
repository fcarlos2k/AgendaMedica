using AgendaMedica.Models;
using MediatR;

namespace AgendaMedica.Commands.MedicalSpecialties;

public class UpdateMedicalSpecialtyCommand : IRequest<MedicalSpecialty>
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public UpdateMedicalSpecialtyCommand(int id, string? name, string? description)
    {
        Id = id;
        Name = name;
        Description = description;
    }
}
