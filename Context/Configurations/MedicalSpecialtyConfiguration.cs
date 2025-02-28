using AgendaMedica.DTOs;
using AgendaMedica.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AgendaMedica.Context.Configurations
{
    public class MedicalSpecialtyConfiguration : IEntityTypeConfiguration<MedicalSpecialty>
    {
        public void Configure(EntityTypeBuilder<MedicalSpecialty> builder)
        {
            builder.ToTable("MedicalSpecialty");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Name).IsRequired().HasMaxLength(100);
            builder.Property(e => e.Description).HasMaxLength(200);

            builder.HasData(
                new MedicalSpecialty
                {
                    Id = 1,
                    Name = "Cardiologia",
                    Description = "Especialidade médica que se ocupa do diagnóstico e tratamento de doenças que acometem o coração e o sistema circulatório."
                },

                new MedicalSpecialty
                {
                    Id = 2,
                    Name = "Dermatologia",
                    Description = "Especialidade médica que se ocupa do diagnóstico e tratamento clínico-cirúrgico das doenças da pele."
                },

                new MedicalSpecialty
                {
                    Id = 3,
                    Name = "Endocrinologia",
                    Description = "Especialidade médica que estuda as ordens do sistema endócrino e suas secreções específicas, chamadas de secreções fisiológicas."
                },

                new MedicalSpecialty
                {
                    Id = 4,
                    Name = "Gastroenterologia",
                    Description = "Especialidade médica que se ocupa do estudo, diagnóstico e tratamento clínico das doenças do aparelho digestivo."
                },

                new MedicalSpecialty
                {
                    Id = 5,
                    Name = "Ginecologia",
                    Description = "Especialidade médica que se ocupa do diagnóstico e tratamento das doenças do sistema reprodutor feminino."
                },

                new MedicalSpecialty
                {
                    Id = 6,
                    Name = "Neurologia",
                    Description = "Especialidade médica que se ocupa do diagnóstico e tratamento de doenças que acometem o sistema nervoso."
                },

                new MedicalSpecialty
                {
                    Id = 7,
                    Name = "Oftalmologia",
                    Description = "Especialidade médica que se ocupa do diagnóstico e tratamento de doenças oculares."
                },

                new MedicalSpecialty
                {
                    Id = 8,
                    Name = "Ortopedia",
                    Description = "Especialidade médica que se ocupa do diagnóstico e tratamento de doenças e deformidades dos ossos, músculos, ligamentos e articulações."
                },

                new MedicalSpecialty
                {
                    Id = 9,
                    Name = "Otorrinolaringologia",
                    Description = "Especialidade médica que se ocupa do diagnóstico e tratamento de doenças do ouvido, nariz e garganta."
                });
        }
    }
}
