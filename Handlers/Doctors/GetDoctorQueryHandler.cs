using AgendaMedica.Interfaces;
using AgendaMedica.Models;
using AgendaMedica.Queries.Doctors;
using MediatR;

namespace AgendaMedica.Handlers.Doctors;

public class GetDoctorsQueryHandler : IRequestHandler<GetDoctorsQuery, IEnumerable<Doctor>>
{
    private readonly IDoctorRepository _doctorRepository;

    public GetDoctorsQueryHandler(IDoctorRepository doctorRepository)
    {
        _doctorRepository = doctorRepository;
    }

    public async Task<IEnumerable<Doctor>> Handle(GetDoctorsQuery request, CancellationToken cancellationToken)
    {
        return await _doctorRepository.GetDoctorsAsync();
    }
}
