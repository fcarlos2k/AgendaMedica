using AgendaMedica.DTOs;
using AgendaMedica.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AgendaMedica.Context.Configurations
{
    public class DoctorConfiguration : IEntityTypeConfiguration<Doctor>
    {
        void IEntityTypeConfiguration<Doctor>.Configure(EntityTypeBuilder<Doctor> builder)
        {
            builder.ToTable("Doctor");
            builder.HasKey(d => d.Id);
            builder.Property(d => d.Name).IsRequired().HasMaxLength(100);


            //builder.HasData(
            //    new Doctor { Id = 1, Name = "Dr. Lucia", MedicalSpecialtyId = 1 },
            //    new Doctor { Id = 2, Name = "Dra. Marcela", MedicalSpecialtyId = 2 },
            //    new Doctor { Id = 3, Name = "Dra. Maria", MedicalSpecialtyId = 3 },
            //    new Doctor { Id = 4, Name = "Dra. Ana", MedicalSpecialtyId = 4 },
            //    new Doctor { Id = 5, Name = "Dr. Pedro", MedicalSpecialtyId = 5 },
            //    new Doctor { Id = 6, Name = "Dr. Carlos", MedicalSpecialtyId = 6 },
            //    new Doctor { Id = 7, Name = "Dr. Luiz", MedicalSpecialtyId = 7 },
            //    new Doctor { Id = 8, Name = "Dr. Paulo", MedicalSpecialtyId = 8 },
            //    new Doctor { Id = 9, Name = "Dr. Marcos", MedicalSpecialtyId = 9 },
            //    new Doctor { Id = 10, Name = "Dr. Lucas", MedicalSpecialtyId = 10 }
            //    );
        }
    }
}
