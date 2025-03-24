using AgendaMedica.Context.Configurations;
using AgendaMedica.Models;
using Microsoft.EntityFrameworkCore;


namespace AgendaMedica.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<Patient> Patients { get; set; }
    public DbSet<MedicalSpecialty> MedicalSpecialties { get; set; }
    public DbSet<MedicalConsultationStatus> MedicalConsultationStatuses { get; set; }
    public DbSet<MedicalConsultation> MedicalConsultations { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new DoctorConfiguration());
        modelBuilder.ApplyConfiguration(new PatientConfiguration());
        modelBuilder.ApplyConfiguration(new MedicalSpecialtyConfiguration());
        modelBuilder.ApplyConfiguration(new MedicalConsultationStatusConfiguration());
        modelBuilder.ApplyConfiguration(new MedicalConsultationConfiguration());
    }
}
