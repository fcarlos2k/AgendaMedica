using AgendaMedica.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AgendaMedica.Context.Configurations
{
    public class MedicalConsultationStatusConfiguration : IEntityTypeConfiguration<MedicalConsultationStatus>
    {
        public void Configure(EntityTypeBuilder<MedicalConsultationStatus> builder)
        {
            builder.ToTable("StatusConsulta");
            builder.HasKey(s => s.Id);
            builder.Property(s => s.Status).IsRequired().HasMaxLength(100);

            builder.HasData(
                new MedicalConsultationStatus { Id = 1, Status = "Agendada" },
                new MedicalConsultationStatus { Id = 2, Status = "Confirmada" },
                new MedicalConsultationStatus { Id = 3, Status = "Cancelada" },
                new MedicalConsultationStatus { Id = 4, Status = "Realizada" },
                new MedicalConsultationStatus { Id = 5, Status = "Remarcada" }
            );
        }
    }
}
