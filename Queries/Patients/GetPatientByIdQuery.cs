using AgendaMedica.DTOs;
using MediatR;

namespace AgendaMedica.Queries.Patients
{
    public class GetDoctorByIdQuery : IRequest<PatientDto>
    {
        public int Id { get; set; }

        public GetDoctorByIdQuery(int id)
        {
            Id = id;
        }
    }

}
