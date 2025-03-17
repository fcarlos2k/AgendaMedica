using AgendaMedica.Commands.MedicalConsultationStatuses;
using AgendaMedica.Interfaces;
using AgendaMedica.Models;
using MediatR;

namespace AgendaMedica.Handlers.MedicalConsultationStatuses
{
    public class CreateMedicalConsultationStatusCommandHandler : IRequestHandler<CreateMedicalConsultationStatusCommand, MedicalConsultationStatus>
    {
        private readonly IMedicalConsultationStatusRepository _medicalConsultationStatusRepository;
        public CreateMedicalConsultationStatusCommandHandler(IMedicalConsultationStatusRepository medicalConsultationStatusRepository)
        {
            _medicalConsultationStatusRepository = medicalConsultationStatusRepository;
        }
        public async Task<MedicalConsultationStatus> Handle(CreateMedicalConsultationStatusCommand request, CancellationToken cancellationToken)
        {
            var medicalConsultationStatus = new MedicalConsultationStatus
            {
                Status = request.Status
            };
            await _medicalConsultationStatusRepository.AddMedicalConsultationStatusAsync(medicalConsultationStatus);
            return medicalConsultationStatus;
        }
    }
}
