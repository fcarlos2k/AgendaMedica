using AgendaMedica.Commands.MedicalSpecialties;
using AgendaMedica.Interfaces;
using AgendaMedica.Models;
using MediatR;

namespace AgendaMedica.Handlers.MedicalSpecialties;

public class UpdateMedicalSpecialtyCommandHandler : IRequestHandler<UpdateMedicalSpecialtyCommand, MedicalSpecialty>
{
    private readonly IMedicalSpecialtyRepository _medicalSpecialtyRepository;
    public UpdateMedicalSpecialtyCommandHandler(IMedicalSpecialtyRepository medicalSpecialtyRepository)
    {
        _medicalSpecialtyRepository = medicalSpecialtyRepository;
    }
    public async Task<MedicalSpecialty> Handle(UpdateMedicalSpecialtyCommand request, CancellationToken cancellationToken)
    {
        var medicalSpecialty = new MedicalSpecialty
        {
            Id = request.Id,
            Name = request.Name,
            Description = request.Description
        };
        await _medicalSpecialtyRepository.UpdateMedicalSpecialtyAsync(medicalSpecialty);
        return medicalSpecialty;
    }
}
