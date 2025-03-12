using AgendaMedica.DTOs;
using AgendaMedica.Interfaces;
using AgendaMedica.Queries.Patients;
using AutoMapper;
using MediatR;

namespace AgendaMedica.Handlers.Patients;



public class GetPatientByIdQueryHandler : IRequestHandler<GetPatientByIdQuery, PatientDto>
{
    private readonly IPatientDapperRepository _patientDapperRepository; 
    //private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    //public GetPatientByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    public GetPatientByIdQueryHandler(IPatientDapperRepository patientDapperRepository, IMapper mapper)
    {
        //_unitOfWork = unitOfWork;
        _patientDapperRepository = patientDapperRepository;
        _mapper = mapper;
    }

    public async Task<PatientDto> Handle(GetPatientByIdQuery request, CancellationToken cancellationToken)
    {
        var patient = await _patientDapperRepository.GetPatientByIdAsync(request.Id);
        return _mapper.Map<PatientDto>(patient);
    }
}
