using AgendaMedica.Commands.Patients;
using AgendaMedica.DTOs;
using AgendaMedica.Interfaces;
using AgendaMedica.Models;
using AutoMapper;
using MediatR;

namespace AgendaMedica.Handlers.Patients
{
    public class UpdatePatientCommandHandler : IRequestHandler<UpdatePatientCommand, PatientDto>
    {
        private readonly IPatientDapperRepository _patientDapperRepository;
        private readonly IMapper _mapper;

        public UpdatePatientCommandHandler(IPatientDapperRepository patientDapperRepository, IMapper mapper)
        {
            _patientDapperRepository = patientDapperRepository;
            _mapper = mapper;
        }

        public async Task<PatientDto> Handle(UpdatePatientCommand request, CancellationToken cancellationToken)
        {
            var patient = new Patient
            {
                Id = request.Id,
                Name = request.Name,
                Cpf = request.Cpf,
                DateOfBirth = request.DateOfBirth,
                Phone = request.Phone,
                Address = request.Address
            };

            var result = await _patientDapperRepository.UpdatePatientAsync(patient);
            if (result == 1)
            {
                var updatedPatient = await _patientDapperRepository.GetPatientByIdAsync(request.Id);
                return _mapper.Map<PatientDto>(updatedPatient);
            }

            return null;
        }
    }
}
