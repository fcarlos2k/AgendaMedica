using AgendaMedica.Commands.Doctors;
using AgendaMedica.Interfaces;
using AgendaMedica.Models;
using MediatR;

namespace AgendaMedica.Handlers.Doctors
{
    public class CreateDoctorCommandHandler : IRequestHandler<CreateDoctorCommand, Doctor>
    {
        private readonly IDoctorRepository _doctorRepository;

        public CreateDoctorCommandHandler(IDoctorRepository doctorRepository)
        {
            _doctorRepository = doctorRepository;
        }

        public async Task<Doctor> Handle(CreateDoctorCommand request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrWhiteSpace(request.Name))
            {
                throw new ArgumentException("Doctor name cannot be null or empty.", nameof(request.Name));
            }

            if (request.MedicalSpecialtyId <= 0)
            {
                throw new ArgumentException("Invalid medical specialty ID.", nameof(request.MedicalSpecialtyId));
            }

            var doctor = new Doctor
            {
                Name = request.Name,
                MedicalSpecialtyId = request.MedicalSpecialtyId
            };

            await _doctorRepository.AddDoctorAsync(doctor);
            return doctor;
        }
    }
}

