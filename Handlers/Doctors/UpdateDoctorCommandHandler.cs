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
            if (request.Id <= 0)
            {
                throw new ArgumentException("Invalid doctor ID.", nameof(request.Id));
            }

            if (string.IsNullOrWhiteSpace(request.Name))
            {
                throw new ArgumentException("Doctor name cannot be null or empty.", nameof(request.Name));
            }

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

