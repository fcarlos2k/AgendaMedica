using AgendaMedica.Interfaces;
using AgendaMedica.Models;
using AgendaMedica.Queries.MedicalSpecialties;
using MediatR;

namespace AgendaMedica.Handlers.MedicalSpecialties;

public class GetMedicalSpecialtyQueryHandler : IRequestHandler<GetMedicalSpecialtiesQuery, IEnumerable<MedicalSpecialty>>
{
    private readonly IMedicalSpecialtyRepository _medicalSpecialtyRepository;
    public GetMedicalSpecialtyQueryHandler(IMedicalSpecialtyRepository medicalSpecialtyRepository)
    {
        _medicalSpecialtyRepository = medicalSpecialtyRepository;
    }
    public async Task<IEnumerable<MedicalSpecialty>> Handle(GetMedicalSpecialtiesQuery request, CancellationToken cancellationToken)
    {
        return await _medicalSpecialtyRepository.GetMedicalSpecialtiesAsync();
    }
}
