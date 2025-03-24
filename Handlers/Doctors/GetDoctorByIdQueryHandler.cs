using AgendaMedica.Interfaces;
using AgendaMedica.Models;
using AgendaMedica.Queries.Doctors;
using MediatR;

namespace AgendaMedica.Handlers.Doctors;

public class GetDoctorByIdQueryHandler : IRequestHandler<GetDoctorByIdQuery, Doctor>
{
    private readonly IDoctorRepository _doctorRepository;

    public GetDoctorByIdQueryHandler(IDoctorRepository doctorRepository)
    {
        _doctorRepository = doctorRepository;
    }

    public async Task<Doctor> Handle(GetDoctorByIdQuery request, CancellationToken cancellationToken)
    {
        return await _doctorRepository.GetDoctorByIdAsync(request.Id);
    }
}
