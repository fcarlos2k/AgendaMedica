using AgendaMedica.DTOs;
using AgendaMedica.Interfaces;
using AgendaMedica.Models;
using AgendaMedica.Queries.Doctor;
using AutoMapper;

namespace AgendaMedica.Handlers.MedicalConsultationStatuses;

public class GetMedicalConsultationStatsByIdQueryHandler
{
    private readonly IMedicalConsultationStatusDapperRepository _medicalConsultationStatsDapperRepository;
    private readonly IMapper _mapper;

    public GetMedicalConsultationStatusByIdQueryHandler(IMedicalConsultationStatusDapperRepository medicalConsultationStatsDapperRepository, IMapper mapper)
    {

        _medicalConsultationStatsDapperRepository = medicalConsultationStatsDapperRepository;
        _mapper = mapper;
    }

    public async Task<MedicalConsultationStatusDto> Handle(GetMedicalConsultationStatusByIdQuery request, CancellationToken cancellationToken)
    {
        var medicalConsultationStats = await _medicalConsultationStatsDapperRepository.GetMedicalConsultationStatusByIdAsync(request.Id);
        return _mapper.Map<MedicalConsultationStatusDto>(medicalConsultationStats);
    }
}