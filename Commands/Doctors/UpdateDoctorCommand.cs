using AgendaMedica.Models;
using MediatR;

namespace AgendaMedica.Commands.Doctors
{
    public class UpdateDoctorCommand : IRequest<Doctor>
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int MedicalSpecialtyId { get; set; }

        public UpdateDoctorCommand(int id, string? name, int medicalSpecialtyId)
        {
            Id = id;
            Name = name;
            MedicalSpecialtyId = medicalSpecialtyId;
        }
    }
}
