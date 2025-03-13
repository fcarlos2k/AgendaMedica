using AgendaMedica.DTOs;
using AgendaMedica.Interfaces;
using AgendaMedica.Queries.MedicalConsultationStatuses;
using AutoMapper;

namespace AgendaMedica.Handlers.MedicalConsultationStatuses;

public class GetMedicalConsultationStatusByIdQueryHandler
{
    private readonly IMedicalConsultationStatusDapperRepository _medicalConsultationStatusDapperRepository;
    
    private readonly IMapper _mapper;

    
    public GetMedicalConsultationStatusByIdQueryHandler(IMedicalConsultationStatusDapperRepository medicalConsultationStatusDapperRepository, IMapper mapper)
    {

        _medicalConsultationStatusDapperRepository = medicalConsultationStatusDapperRepository;
        _mapper = mapper;
    }

    public async Task<MedicalConsultationStatusDto> Handle(GetMedicalConsultationStatusByIdQuery request, CancellationToken cancellationToken)
    {
        var medicalConsultationStatus = await _medicalConsultationStatusDapperRepository.GetMedicalConsultationStatusByIdAsync(request.Id);
        return _mapper.Map<MedicalConsultationStatusDto>(medicalConsultationStatus);
    }
}