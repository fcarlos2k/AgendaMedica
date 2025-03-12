using AgendaMedica.DTOs;
using MediatR;

namespace AgendaMedica.Commands.MedicalConsultationStatus
{
    public class CreateMedicalConsultationStatusCommand : IRequest<MedicalConsultationStatusDto>
    {
        public string? Name { get; set; }
        public string Status { get; internal set; }

        public CreateMedicalConsultationStatusCommand(string? name)
        {
            Name = name;
        }
    }
}
