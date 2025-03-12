using System.Numerics;
using AgendaMedica.DTOs;
using AgendaMedica.Interfaces;
using AgendaMedica.Models;
using AgendaMedica.Queries.Doctor;
using AgendaMedica.Repositories;
using AutoMapper;
using MediatR;

namespace AgendaMedica.Handlers.Doctors
{
    public class GetDoctorQueryHandler : IRequestHandler<GetDoctorsQuery, IEnumerable<DoctorDto>>
    {
        private readonly IDoctorDapperRepository _doctorDapperRepository;
        private readonly IMapper _mapper;

        public GetDoctorQueryHandler(IDoctorDapperRepository doctorDapperRepository, IMapper mapper)
        {
            _doctorDapperRepository = doctorDapperRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<DoctorDto>> Handle(GetDoctorsQuery request, CancellationToken cancellationToken)
        {
            var doctors = await _doctorDapperRepository.GetDoctorsAsync();
            return _mapper.Map<IEnumerable<DoctorDto>>(doctors.Value);
            
        }
    }
}