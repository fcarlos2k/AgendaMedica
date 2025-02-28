using AgendaMedica.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AgendaMedica.Context.Configurations
{
    public class MedicalConsultationConfiguration : IEntityTypeConfiguration<MedicalConsultation>
    {
        public void Configure(EntityTypeBuilder<MedicalConsultation> builder)
        {
            builder.ToTable("MedicalConsultation");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.ConsultationDate).IsRequired();
            builder.Property(c => c.ConsultationTime).IsRequired();
            builder.Property(c => c.DoctorId).IsRequired();
            builder.Property(c => c.PatientId).IsRequired();
            builder.Property(c => c.MedicalSpecialtyId).IsRequired();
            builder.Property(c => c.MedicalConsultationStatusId).IsRequired();



            builder.HasOne(c => c.Doctor)
                .WithMany()
                .HasForeignKey(c => c.DoctorId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(c => c.Patient)
                .WithMany()
                .HasForeignKey(c => c.PatientId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(c => c.MedicalSpecialty)
                .WithMany()
                .HasForeignKey(c => c.MedicalSpecialtyId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(c => c.MedicalConsultationStatus)
                .WithMany()
                .HasForeignKey(c => c.MedicalConsultationStatusId)
                .OnDelete(DeleteBehavior.NoAction); 
        }
    }
}