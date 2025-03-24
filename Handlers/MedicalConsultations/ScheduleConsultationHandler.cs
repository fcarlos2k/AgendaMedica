using AgendaMedica.Commands.MedicalConsultations;
using AgendaMedica.Interfaces;
using AgendaMedica.Models;
using MediatR;

namespace AgendaMedica.Handlers.MedicalConsultations;

public class ScheduleConsultationHandler : IRequestHandler<ScheduleMedicalConsultationCommand, int>
{
    private readonly IMedicalConsultationRepository _repository;

    public ScheduleConsultationHandler(IMedicalConsultationRepository repository)
    {
        _repository = repository;
    }

    public async Task<int> Handle(ScheduleMedicalConsultationCommand request, CancellationToken cancellationToken)
    {
        bool isAvailable = await _repository.IsDoctorAvailableAsync(request.DoctorId, request.MedicalConsultationDate, request.MedicalConsultationTime);
        
        if (!isAvailable)
        {
            throw new InvalidOperationException("O médico não está disponível neste horário.");
        }

        var consultation = new MedicalConsultation
        {
            PatientId = request.PatientId,
            ConsultationDate = request.MedicalConsultationDate,
            ConsultationTime = request.MedicalConsultationTime,
            MedicalSpecialtyId = request.MedicalSpecialtyId,
            DoctorId = request.DoctorId,
            MedicalConsultationStatusId = 1
        };
        return await _repository.AddMedicalConsultationAsync(consultation);
    }
}
