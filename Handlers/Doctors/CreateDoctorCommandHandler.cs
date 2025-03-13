using AgendaMedica.Commands.Doctors;
using AgendaMedica.Context;
using AgendaMedica.Interfaces;
using AgendaMedica.Models;
using MediatR;

namespace AgendaMedica.Handlers.Doctors;

public class CreateDoctorCommandHandler : IRequestHandler<CreateDoctorCommand, Doctor>
{
    private readonly AppDbContext _context;

    public CreateDoctorCommandHandler(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Doctor> Handle(CreateDoctorCommand request, CancellationToken cancellationToken)
    {
        var doctor = new Doctor
        {
            Name = request.Name,
            MedicalSpecialtyId = request.MedicalSpecialtyId
        };

        _context.Doctors.Add(doctor);
        await _context.SaveChangesAsync(cancellationToken);

        return doctor;
    }
}