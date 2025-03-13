using AgendaMedica.Context;

namespace AgendaMedica.Handlers.Doctors;

public class GetDoctorByIdQueryHandler //: IRequestHandler<GetDoctorByIdQuery, Doctor>
{
    private readonly AppDbContext _appDbContext;

    public GetDoctorByIdQueryHandler(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    //public async Task<Doctor> Handle(GetDoctorByIdQuery request, CancellationToken cancellationToken)
    //{
    //    var doctor = await _appDbContext.Doctors
    //            .Include(d => d.MedicalSpecialty)
    //            .FirstOrDefaultAsync(d => d.Id == request.Id, cancellationToken);
    //    return doctor;
    //}
}
