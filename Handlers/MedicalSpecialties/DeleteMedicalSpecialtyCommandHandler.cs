using AgendaMedica.Commands.MedicalSpecialties;
using AgendaMedica.Interfaces;
using MediatR;

namespace AgendaMedica.Handlers.MedicalSpecialties;

public class DeleteMedicalSpecialtyCommandHandler : IRequestHandler<DeleteMedicalSpecialtyCommand, bool>
{
    private readonly IMedicalSpecialtyRepository _medicalSpecialtyRepository;
    public DeleteMedicalSpecialtyCommandHandler(IMedicalSpecialtyRepository medicalSpecialtyRepository)
    {
        _medicalSpecialtyRepository = medicalSpecialtyRepository;
    }
    public async Task<bool> Handle(DeleteMedicalSpecialtyCommand request, CancellationToken cancellationToken)
    {
        var result = await _medicalSpecialtyRepository.DeleteMedicalSpecialtyAsync(request.Id);
        return result == 1;
    }
}
