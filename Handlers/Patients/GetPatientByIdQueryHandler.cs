using AgendaMedica.Interfaces;
using AgendaMedica.Models;
using AgendaMedica.Queries.Patients;
using MediatR;

namespace AgendaMedica.Handlers.Patients;

public class GetPatientByIdQueryHandler : IRequestHandler<GetPatientByIdQuery, Patient>
{
    private readonly IPatientRepository _patientRepository;

    public GetPatientByIdQueryHandler(IPatientRepository patientRepository)
    {
        _patientRepository = patientRepository;
    }

    public async Task<Patient> Handle(GetPatientByIdQuery request, CancellationToken cancellationToken)
    {
        return await _patientRepository.GetPatientByIdAsync(request.Id);
    }
}
