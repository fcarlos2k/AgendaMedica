using AgendaMedica.Interfaces;
using AgendaMedica.Models;
using AgendaMedica.Queries.MedicalSpecialties;
using MediatR;

namespace AgendaMedica.Handlers.MedicalSpecialties;

public class GetMedicalSpecialtyByIdQueryHandler : IRequestHandler<GetMedicalSpecialtyByIdQuery, MedicalSpecialty>
{
    private readonly IMedicalSpecialtyRepository _medicalSpecialtyRepository;
    public GetMedicalSpecialtyByIdQueryHandler(IMedicalSpecialtyRepository medicalSpecialtyRepository)
    {
        _medicalSpecialtyRepository = medicalSpecialtyRepository;
    }
    public async Task<MedicalSpecialty> Handle(GetMedicalSpecialtyByIdQuery request, CancellationToken cancellationToken)
    {
        return await _medicalSpecialtyRepository.GetMedicalSpecialtyByIdAsync(request.Id);
    }

}
