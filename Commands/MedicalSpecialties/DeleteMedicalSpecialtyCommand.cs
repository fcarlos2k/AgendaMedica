using MediatR;

namespace AgendaMedica.Commands.MedicalSpecialties;

public class DeleteMedicalSpecialtyCommand : IRequest<bool>
{
    public int Id { get; set; }
    public DeleteMedicalSpecialtyCommand(int id)
    {
        Id = id;
    }
}
