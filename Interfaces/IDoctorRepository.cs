using AgendaMedica.DTOs;

namespace AgendaMedica.Interfaces
{
    public interface IDoctorRepository
    {
        Task<IEnumerable<DoctorDto>> GetAllDoctor();
        Task<DoctorDto>GetDoctorById(int id);
        Task<DoctorDto>AddDoctor(DoctorDto doctorDto);
        void UpdateDoctor(DoctorDto doctorDto);
        Task<DoctorDto>DeleteDoctor(int id);
    }
}