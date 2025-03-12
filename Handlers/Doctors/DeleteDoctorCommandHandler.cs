using AgendaMedica.Commands.Doctors;
using AgendaMedica.Interfaces;
using MediatR;

namespace AgendaMedica.Handlers.Doctors
{
    public class DeleteDoctorCommandHandler : IRequestHandler<DeleteDoctorCommand, bool>
    {
        private readonly IDoctorDapperRepository _doctorDapperRepository;

        public DeleteDoctorCommandHandler(IDoctorDapperRepository doctorDapperRepository)
        {
            _doctorDapperRepository = doctorDapperRepository;
        }

        public async Task<bool> Handle(DeleteDoctorCommand request, CancellationToken cancellationToken)
        {
            var result = await _doctorDapperRepository.DeleteDoctorAsync(request.Id);
            return result == 1;
        }
    }
}
