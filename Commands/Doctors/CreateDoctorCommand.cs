using AgendaMedica.Models;
using MediatR;

namespace AgendaMedica.Commands.Doctors
{
    public class CreateDoctorCommand : IRequest<Doctor>
    {
        public string? Name { get; set; }
        public int MedicalSpecialtyId { get; set; }

        public CreateDoctorCommand(string? name, int medicalSpecialtyId)
        {
            Name = name;
            MedicalSpecialtyId = medicalSpecialtyId;
        }
    }
}
