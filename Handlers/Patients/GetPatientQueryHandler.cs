using AgendaMedica.Interfaces;
using AgendaMedica.Models;
using AgendaMedica.Queries.Patients;
using MediatR;

namespace AgendaMedica.Handlers.Patients;

public class GetPatientsQueryHandler : IRequestHandler<GetPatientsQuery, IEnumerable<Patient>>
{
    private readonly IPatientRepository _patientRepository;

    public GetPatientsQueryHandler(IPatientRepository patientRepository)
    {
        _patientRepository = patientRepository;
    }

    public async Task<IEnumerable<Patient>> Handle(GetPatientsQuery request, CancellationToken cancellationToken)
    {
        return await _patientRepository.GetPatientsAsync();
    }
}
