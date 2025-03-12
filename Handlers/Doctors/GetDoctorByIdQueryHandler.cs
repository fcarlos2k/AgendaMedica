using AgendaMedica.DTOs;
using AgendaMedica.Interfaces;
using AgendaMedica.Queries.Doctor;
using AutoMapper;
using MediatR;

namespace AgendaMedica.Handlers.Doctors;

public class GetDoctorByIdQueryHandler : IRequestHandler<GetDoctorByIdQuery, DoctorDto>
{
    private readonly IDoctorDapperRepository _doctorDapperRepository; 
    //private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    //public GetDoctorByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    public GetDoctorByIdQueryHandler(IDoctorDapperRepository doctorDapperRepository, IMapper mapper)
    {
        //_unitOfWork = unitOfWork;
        _doctorDapperRepository = doctorDapperRepository;
        _mapper = mapper;
    }

    public async Task<DoctorDto> Handle(GetDoctorByIdQuery request, CancellationToken cancellationToken)
    {
        var doctor = await _doctorDapperRepository.GetDoctorByIdAsync(request.Id);
        return _mapper.Map<DoctorDto>(doctor);
    }
}
