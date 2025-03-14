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
