using AgendaMedica.DTOs;
using MediatR;

namespace AgendaMedica.Queries.Patients
{
    public class GetPatientByIdQuery : IRequest<PatientDto>
    {
        public int Id { get; set; }

        public GetPatientByIdQuery(int id)
        {
            Id = id;
        }
    }

}
