using System.Data.Entity;
using AgendaMedica.Commands.Doctors;
using AgendaMedica.Context;
using AgendaMedica.Models;
using MediatR;

namespace AgendaMedica.Handlers.Doctors
{
    public class UpdateDoctorCommandHandler : IRequestHandler<UpdateDoctorCommand, Doctor>
    {
        private readonly AppDbContext _context;

        public UpdateDoctorCommandHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Doctor> Handle(UpdateDoctorCommand request, CancellationToken cancellationToken)
        {
            var doctor = await _context.Doctors.FirstOrDefaultAsync(d => d.Id == request.Id, cancellationToken);
            if (doctor == null) return null;

            doctor.Name = request.Name;
            doctor.MedicalSpecialtyId = request.MedicalSpecialtyId;

            await _context.SaveChangesAsync(cancellationToken);

            return doctor;
        }
    }
}
