using AgendaMedica.Commands.Patients;
using AgendaMedica.Interfaces;
using MediatR;

namespace AgendaMedica.Handlers.Patients
{
    public class DeletePatientCommandHandler : IRequestHandler<DeletePatientCommand, bool>
    {
        private readonly IPatientDapperRepository _patientDapperRepository;

        public DeletePatientCommandHandler(IPatientDapperRepository patientDapperRepository)
        {
            _patientDapperRepository = patientDapperRepository;
        }

        public async Task<bool> Handle(DeletePatientCommand request, CancellationToken cancellationToken)
        {
            var result = await _patientDapperRepository.DeletePatientAsync(request.Id);
            return result == 1;
        }
    }
}
