using AgendaMedica.Commands.Patients;
using AgendaMedica.DTOs;
using AgendaMedica.Interfaces;
using AgendaMedica.Models;
using AutoMapper;
using MediatR;

namespace AgendaMedica.Handlers.Patients;

public class CreatePatientCommandHandler : IRequestHandler<CreatePatientCommand, PatientDto>
{

    private readonly IMapper _mapper;
    private readonly IPatientDapperRepository _patientDapperRepository;

    public CreatePatientCommandHandler(IPatientDapperRepository patientDapperRepository, IMapper mapper)
    {

        _patientDapperRepository = patientDapperRepository;
        _mapper = mapper;
    }

    public async Task<PatientDto> Handle(CreatePatientCommand request, CancellationToken cancellationToken)
    {
        var patient = new Patient
        {
            Name = request.Name,
            Cpf = request.Cpf,
            DateOfBirth = request.DateOfBirth,
            Phone = request.Phone,
            Address = request.Address
        };

        await _patientDapperRepository.AddPatientAsync(patient);

        return _mapper.Map<PatientDto>(patient);
    }
}
