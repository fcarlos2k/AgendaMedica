using AgendaMedica.Commands.Patients;
using AgendaMedica.Interfaces;
using AgendaMedica.Models;
using MediatR;

namespace AgendaMedica.Handlers.Patients
{
    public class UpdatePatientCommandHandler : IRequestHandler<UpdatePatientCommand, Patient>
    {
        private readonly IPatientRepository _patientRepository;

        public UpdatePatientCommandHandler(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }

        public async Task<Patient> Handle(UpdatePatientCommand request, CancellationToken cancellationToken)
        {

            if (request.Id <= 0)
            {
                throw new ArgumentException("Invalid patient ID.", nameof(request.Id));
            }

            if (string.IsNullOrWhiteSpace(request.Name))
            {
                throw new ArgumentException("Patient name cannot be null or empty.", nameof(request.Name));
            }

            if (string.IsNullOrWhiteSpace(request.Cpf))
            {
                throw new ArgumentException("Patient CPF cannot be null or empty.", nameof(request.Cpf));
            }

            var patient = new Patient
            {
                Id = request.Id,
                Name = request.Name,
                Cpf = request.Cpf,
                DateOfBirth = request.DateOfBirth,
                Phone = request.Phone,
                Address = request.Address
            };

            await _patientRepository.UpdatePatientAsync(patient);
            return patient;
        }
    }
}
