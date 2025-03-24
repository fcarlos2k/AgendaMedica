using AgendaMedica.Interfaces;
using AgendaMedica.Models;
using AgendaMedica.Queries.Doctors;
using MediatR;

namespace AgendaMedica.Handlers.Doctors;

public class GetDoctorsBySpecialtyHandler : IRequestHandler<GetDoctorsBySpecialty, IEnumerable<Doctor>>
{
    private readonly IDoctorRepository _doctorRepository;

    public GetDoctorsBySpecialtyHandler(IDoctorRepository doctorRepository)
    {
        _doctorRepository = doctorRepository;
    }

    public async Task<IEnumerable<Doctor>> Handle(GetDoctorsBySpecialty request, CancellationToken cancellationToken)
    {
        return await _doctorRepository.GetDoctorsBySpecialtyAsync(request.Id);
    }
}
