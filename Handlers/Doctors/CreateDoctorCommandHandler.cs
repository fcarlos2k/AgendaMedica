using AgendaMedica.Commands.Doctors;
using AgendaMedica.DTOs;
using AgendaMedica.Interfaces;
using AgendaMedica.Models;
using AutoMapper;
using MediatR;

namespace AgendaMedica.Handlers.Doctors;

public class CreateDoctorCommandHandler : IRequestHandler<CreateDoctorCommand, DoctorDto>
{

    private readonly IMapper _mapper;
    private readonly IDoctorDapperRepository _doctorDapperRepository;

    public CreateDoctorCommandHandler(IDoctorDapperRepository doctorDapperRepository, IMapper mapper)
    {

        _doctorDapperRepository = doctorDapperRepository;
        _mapper = mapper;
    }

    public async Task<DoctorDto> Handle(CreateDoctorCommand request, CancellationToken cancellationToken)
    {
        var doctor = new Doctor
        {

            Name = request.Name,
            MedicalSpecialtyId = request.MedicalSpecialtyId
        };

        await _doctorDapperRepository.AddDoctorAsync(doctor);

        return _mapper.Map<DoctorDto>(doctor);
    }
}
