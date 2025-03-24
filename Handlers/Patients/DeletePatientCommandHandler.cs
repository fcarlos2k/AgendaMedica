using AgendaMedica.Commands.Patients;
using AgendaMedica.Interfaces;
using MediatR;

namespace AgendaMedica.Handlers.Patients;

public class DeletePatientCommandHandler : IRequestHandler<DeletePatientCommand, bool>
{
    private readonly IPatientRepository _patientRepository;

    public DeletePatientCommandHandler(IPatientRepository patientRepository)
    {
        _patientRepository = patientRepository;
    }

    public async Task<bool> Handle(DeletePatientCommand request, CancellationToken cancellationToken)
    {
        var result = await _patientRepository.DeletePatientAsync(request.Id);
        return result == 1;
    }
}
