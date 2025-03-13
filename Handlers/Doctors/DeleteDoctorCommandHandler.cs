using AgendaMedica.Commands.Doctors;
using AgendaMedica.Interfaces;
using MediatR;

namespace AgendaMedica.Handlers.Doctors
{
    public class DeleteDoctorCommandHandler : IRequestHandler<DeleteDoctorCommand, bool>
    {
        private readonly IDoctorRepository _doctorRepository;

        public DeleteDoctorCommandHandler(IDoctorRepository doctorRepository)
        {
            _doctorRepository = doctorRepository;
        }

        public async Task<bool> Handle(DeleteDoctorCommand request, CancellationToken cancellationToken)
        {
            var result = await _doctorRepository.DeleteDoctorAsync(request.Id);
            return result == 1;
        }
    }
}
