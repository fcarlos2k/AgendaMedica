using AgendaMedica.Commands.Patients;
using AgendaMedica.Interfaces;
using AgendaMedica.Models;
using MediatR;

namespace AgendaMedica.Handlers.Patients
{
    public class CreatePatientCommandHandler : IRequestHandler<CreatePatientCommand, Patient>
    {
        private readonly IPatientRepository _patientRepository;

        public CreatePatientCommandHandler(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }

        public async Task<Patient> Handle(CreatePatientCommand request, CancellationToken cancellationToken)
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

            await _patientRepository.AddPatientAsync(patient);
            return patient;
        }
    }
}

