using AgendaMedica.Commands.Doctors;
using AgendaMedica.DTOs;
using AgendaMedica.Interfaces;
using AgendaMedica.Models;
using AutoMapper;
using MediatR;

namespace AgendaMedica.Handlers.Doctors
{
    public class UpdateDoctorCommandHandler : IRequestHandler<UpdateDoctorCommand, DoctorDto>
    {
        private readonly IDoctorDapperRepository _doctorDapperRepository;
        private readonly IMapper _mapper;

        public UpdateDoctorCommandHandler(IDoctorDapperRepository doctorDapperRepository, IMapper mapper)
        {
            _doctorDapperRepository = doctorDapperRepository;
            _mapper = mapper;
        }

        public async Task<DoctorDto> Handle(UpdateDoctorCommand request, CancellationToken cancellationToken)
        {
            var doctor = new Doctor
            {
                Id = request.Id,
                Name = request.Name,
                MedicalSpecialtyId = request.MedicalSpecialtyId
            };

            var result = await _doctorDapperRepository.UpdateDoctorAsync(doctor);
            if (result == 1)
            {
                var updatedDoctor = await _doctorDapperRepository.GetDoctorByIdAsync(request.Id);
                return _mapper.Map<DoctorDto>(updatedDoctor);
            }

            return null;
        }
    }
}
