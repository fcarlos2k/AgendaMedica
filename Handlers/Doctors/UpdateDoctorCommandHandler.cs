using AgendaMedica.Commands.Doctors;
using AgendaMedica.Interfaces;
using AgendaMedica.Models;
using MediatR;

namespace AgendaMedica.Handlers.Doctors
{
    public class UpdateDoctorCommandHandler : IRequestHandler<UpdateDoctorCommand, Doctor>
    {
        private readonly IDoctorRepository _doctorRepository;

        public UpdateDoctorCommandHandler(IDoctorRepository doctorRepository)
        {
            _doctorRepository = doctorRepository;
        }

        public async Task<Doctor> Handle(UpdateDoctorCommand request, CancellationToken cancellationToken)
        {
            var doctor = new Doctor
            {
                Id = request.Id,
                Name = request.Name,
                MedicalSpecialtyId = request.MedicalSpecialtyId
            };

            await _doctorRepository.UpdateDoctorAsync(doctor);
            return doctor;
        }
    }
}

