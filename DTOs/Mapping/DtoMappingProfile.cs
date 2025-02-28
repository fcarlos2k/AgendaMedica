using AgendaMedica.Models;
using AgendaMedica.DTOs;
using AutoMapper;

namespace AgendaMedica.DTOs.Mapping
{
    public class DtoMappingProfile : Profile
    {
        public DtoMappingProfile()
        {
            CreateMap<Doctor, DoctorDto>().ReverseMap() ;
            CreateMap<MedicalSpecialty, MedicalSpecialtyDto>().ReverseMap();
            CreateMap<Patient, PatientDto>().ReverseMap();
            CreateMap<MedicalConsultationStatus, MedicalConsultationStatusDto>().ReverseMap();
            CreateMap<MedicalConsultation, MedicalConsultationDto>().ReverseMap();
        }
    }
}