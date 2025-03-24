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
        if (request.Id <= 0)
        {
            throw new ArgumentException("Invalid medical specialty ID.", nameof(request.Id));
        }

        if (string.IsNullOrWhiteSpace(request.Name))
        {
            throw new ArgumentException("Medical specialty name cannot be null or empty.", nameof(request.Name));
        }

        if (string.IsNullOrWhiteSpace(request.Description))
        {
            throw new ArgumentException("Medical specialty description cannot be null or empty.", nameof(request.Description));
        }

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
