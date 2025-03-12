using AgendaMedica.Commands.Doctors;
using AgendaMedica.Commands.MedicalConsultationStatus;
using AgendaMedica.DTOs;
using AgendaMedica.Interfaces;
using AgendaMedica.Models;
using AutoMapper;

namespace AgendaMedica.Handlers.MedicalConsultationStatuses;

public class CreateMedicalConsultationStatusCommandHandler
{
    private readonly IMapper _mapper;
    private readonly IMedicalConsultationStatusDapperRepository _medicalConsultationStatusDapperRepository;

    public CreateMedicalConsultationStatusCommandHandler(IMedicalConsultationStatusDapperRepository medicalConsultationStatusDapperRepository, IMapper mapper)
    {

        _medicalConsultationStatusDapperRepository = medicalConsultationStatusDapperRepository;
        _mapper = mapper;
    }

    public async Task<MedicalConsultationStatusDto> Handle(CreateMedicalConsultationStatusCommand request, CancellationToken cancellationToken)
    {
        var medicalConsultationStatus = new MedicalConsultationStatus
        {
            Status = request.Status,
        };

        await _medicalConsultationStatusDapperRepository.AddMedicalConsultationStatusAsync(medicalConsultationStatus);

        return _mapper.Map<MedicalConsultationStatusDto>(medicalConsultationStatus);
    }
}