using AgendaMedica.DTOs;
using MediatR;

namespace AgendaMedica.Commands.Patients
{
    public class CreatePatientCommand : IRequest<PatientDto>
    {
        public string? Name { get; set; }
        public string? Cpf { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }

        public CreatePatientCommand(string? name, string? cpf, DateOnly dateOfBirth, string? phone, string? address)
        {
            Name = name;
            Cpf = cpf;
            DateOfBirth = dateOfBirth;
            Phone = phone;
            Address = address;
        }
    }
}
