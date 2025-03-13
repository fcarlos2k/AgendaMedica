using AgendaMedica.Context;
using AgendaMedica.Interfaces;
using AgendaMedica.Models;
using AgendaMedica.Queries.Doctors;
using MediatR;

namespace AgendaMedica.Handlers.Doctors
{
    public class GetDoctorQueryHandler : IRequestHandler<GetDoctorsQuery, IEnumerable<Doctor>>
    {
        private readonly AppDbContext _appDbContext;
        private readonly IDoctorRepository _doctorRepository;

        public GetDoctorQueryHandler(AppDbContext appDbContext, IDoctorRepository doctorRepository)
        {
            _appDbContext = appDbContext;
            _doctorRepository = doctorRepository;
        }

        public async Task<IEnumerable<Doctor>> Handle(GetDoctorsQuery request, CancellationToken cancellationToken)
        {
            //var doctors = await _appDbContext.Doctors
            //    .Include(d => d.MedicalSpecialty)
            //    .ToListAsync(cancellationToken);

            return await _doctorRepository.GetDoctorsAsync();
        }
    }
}