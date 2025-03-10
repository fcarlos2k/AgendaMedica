using AgendaMedica.DTOs;
using MediatR;

namespace AgendaMedica.Commands.Patients
{
    public class UpdatePatientCommand : IRequest<PatientDto>
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Cpf { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }

        public UpdatePatientCommand(int id, string? name, string? cpf, DateOnly dateOfBirth, string? phone, string? address)
        {
            Id = id;
            Name = name;
            Cpf = cpf;
            DateOfBirth = dateOfBirth;
            Phone = phone;
            Address = address;
        }
    }
}
