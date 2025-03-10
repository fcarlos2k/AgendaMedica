using System.Numerics;
using AgendaMedica.DTOs;
using AgendaMedica.Interfaces;
using AgendaMedica.Models;
using AgendaMedica.Queries.Doctor;
using AgendaMedica.Queries.Patients;
using AgendaMedica.Repositories;
using AutoMapper;
using MediatR;

namespace AgendaMedica.Handlers.Patients
{
    public class GetPatientQueryHandler : IRequestHandler<GetPatientsQuery, IEnumerable<PatientDto>>
    {
        private readonly IPatientDapperRepository _patientDapperRepository;
        private readonly IMapper _mapper;

        public GetPatientQueryHandler(IPatientDapperRepository patientDapperRepository, IMapper mapper)
        {
            _patientDapperRepository = patientDapperRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PatientDto>> Handle(GetPatientsQuery request, CancellationToken cancellationToken)
        {
            var patients = await _patientDapperRepository.GetPatientsAsync();
            return _mapper.Map<IEnumerable<PatientDto>>(patients);
            
        }
    }
}