using MediatR;

namespace AgendaMedica.Commands.Doctors
{
    public class DeleteDoctorCommand : IRequest<bool>
    {
        public int Id { get; set; }

        public DeleteDoctorCommand(int id)
        {
            Id = id;
        }
    }
}
