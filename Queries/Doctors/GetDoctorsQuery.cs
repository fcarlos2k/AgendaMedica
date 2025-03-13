using AgendaMedica.Models;
using MediatR;
using System.Collections.Generic;

namespace AgendaMedica.Queries.Doctors
{
    public class GetDoctorsQuery : IRequest<IEnumerable<Doctor>>
    {
    }
}