using AgendaMedica.Commands.MedicalSpecialties;
using AgendaMedica.Interfaces;
using AgendaMedica.Models;
using MediatR;

namespace AgendaMedica.Handlers.MedicalSpecialties;

public class CreateMedicalSpecialtyCommandHandler : IRequestHandler<CreateMedicalSpecialtyCommand, MedicalSpecialty>
{
    private readonly IMedicalSpecialtyRepository _medicalSpecialtyRepository;
    public CreateMedicalSpecialtyCommandHandler(IMedicalSpecialtyRepository medicalSpecialtyRepository)
    {
        _medicalSpecialtyRepository = medicalSpecialtyRepository;
    }
    public async Task<MedicalSpecialty> Handle(CreateMedicalSpecialtyCommand request, CancellationToken cancellationToken)
    {
        var medicalSpecialty = new MedicalSpecialty
        {
            Name = request.Name,
            Description = request.Description
        };
        await _medicalSpecialtyRepository.AddMedicalSpecialtyAsync(medicalSpecialty);
        return medicalSpecialty;
    }
}
