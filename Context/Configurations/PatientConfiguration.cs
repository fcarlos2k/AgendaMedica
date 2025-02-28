using AgendaMedica.DTOs;
using AgendaMedica.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AgendaMedica.Context.Configurations;

public class PatientConfiguration : IEntityTypeConfiguration<Patient>
{
    public void Configure(EntityTypeBuilder<Patient> builder)
    {
        builder.ToTable("Patient");
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Name).IsRequired().HasMaxLength(100);
        builder.Property(p => p.Cpf).IsRequired().HasMaxLength(11);
        builder.Property(p => p.DateOfBirth).IsRequired();
        builder.Property(p => p.Phone).IsRequired().HasMaxLength(11);
        builder.Property(p => p.Address).HasMaxLength(200);

        builder.HasData( new Patient
        {
            Id = 1, Name = "Maria",
            Cpf = "12345678901",
            DateOfBirth = new DateOnly(1990, 1, 1),
            Phone = "11999999999", Address = "Rua 1" 
        });
        builder.HasData(new Patient 
        { 
            Id = 2, Name = "João", 
            Cpf = "12345678902", 
            DateOfBirth = new DateOnly(1991, 2, 2), 
            Phone = "11999999998", 
            Address = "Rua 2" });
        builder.HasData(new Patient
        {
            Id = 3,
            Name = "José",
            Address = "Rua 3",
            Cpf = "12345678903",
            DateOfBirth = new DateOnly(1992, 3, 3),
            Phone = "11999999997"
        });
        builder.HasData(new Patient
        {
            Id = 4,
            Name = "Ana",
            Address = "Rua 4",
            Cpf = "12345678904",
            DateOfBirth = new DateOnly(1993, 4, 4),
            Phone = "11999999996"
        });
        builder.HasData(new Patient
        {
            Id = 5,
            Name = "Pedro",
            Address = "Rua 5",
            Cpf = "12345678905",
            DateOfBirth = new DateOnly(1994, 5, 5),
            Phone = "11999999995"
        });
    }
}
