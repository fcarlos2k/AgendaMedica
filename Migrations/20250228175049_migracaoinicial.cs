using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AgendaMedica.Migrations
{
    /// <inheritdoc />
    public partial class migracaoinicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MedicalSpecialty",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalSpecialty", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Patient",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Cpf = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    DateOfBirth = table.Column<DateOnly>(type: "date", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patient", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StatusConsulta",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatusConsulta", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Doctor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    MedicalSpecialtyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Doctor_MedicalSpecialty_MedicalSpecialtyId",
                        column: x => x.MedicalSpecialtyId,
                        principalTable: "MedicalSpecialty",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MedicalConsultation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ConsultationDate = table.Column<DateOnly>(type: "date", nullable: false),
                    ConsultationTime = table.Column<int>(type: "int", nullable: false),
                    DoctorId = table.Column<int>(type: "int", nullable: false),
                    MedicalSpecialtyId = table.Column<int>(type: "int", nullable: false),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    MedicalConsultationStatusId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalConsultation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MedicalConsultation_Doctor_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctor",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MedicalConsultation_MedicalSpecialty_MedicalSpecialtyId",
                        column: x => x.MedicalSpecialtyId,
                        principalTable: "MedicalSpecialty",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MedicalConsultation_Patient_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patient",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MedicalConsultation_StatusConsulta_MedicalConsultationStatusId",
                        column: x => x.MedicalConsultationStatusId,
                        principalTable: "StatusConsulta",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "MedicalSpecialty",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Especialidade médica que se ocupa do diagnóstico e tratamento de doenças que acometem o coração e o sistema circulatório.", "Cardiologia" },
                    { 2, "Especialidade médica que se ocupa do diagnóstico e tratamento clínico-cirúrgico das doenças da pele.", "Dermatologia" },
                    { 3, "Especialidade médica que estuda as ordens do sistema endócrino e suas secreções específicas, chamadas de secreções fisiológicas.", "Endocrinologia" },
                    { 4, "Especialidade médica que se ocupa do estudo, diagnóstico e tratamento clínico das doenças do aparelho digestivo.", "Gastroenterologia" },
                    { 5, "Especialidade médica que se ocupa do diagnóstico e tratamento das doenças do sistema reprodutor feminino.", "Ginecologia" },
                    { 6, "Especialidade médica que se ocupa do diagnóstico e tratamento de doenças que acometem o sistema nervoso.", "Neurologia" },
                    { 7, "Especialidade médica que se ocupa do diagnóstico e tratamento de doenças oculares.", "Oftalmologia" },
                    { 8, "Especialidade médica que se ocupa do diagnóstico e tratamento de doenças e deformidades dos ossos, músculos, ligamentos e articulações.", "Ortopedia" },
                    { 9, "Especialidade médica que se ocupa do diagnóstico e tratamento de doenças do ouvido, nariz e garganta.", "Otorrinolaringologia" }
                });

            migrationBuilder.InsertData(
                table: "Patient",
                columns: new[] { "Id", "Address", "Cpf", "DateOfBirth", "Name", "Phone" },
                values: new object[,]
                {
                    { 1, "Rua 1", "12345678901", new DateOnly(1990, 1, 1), "Maria", "11999999999" },
                    { 2, "Rua 2", "12345678902", new DateOnly(1991, 2, 2), "João", "11999999998" },
                    { 3, "Rua 3", "12345678903", new DateOnly(1992, 3, 3), "José", "11999999997" },
                    { 4, "Rua 4", "12345678904", new DateOnly(1993, 4, 4), "Ana", "11999999996" },
                    { 5, "Rua 5", "12345678905", new DateOnly(1994, 5, 5), "Pedro", "11999999995" }
                });

            migrationBuilder.InsertData(
                table: "StatusConsulta",
                columns: new[] { "Id", "Status" },
                values: new object[,]
                {
                    { 1, "Agendada" },
                    { 2, "Cancelada" },
                    { 3, "Realizada" },
                    { 4, "Remarcada" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Doctor_MedicalSpecialtyId",
                table: "Doctor",
                column: "MedicalSpecialtyId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalConsultation_DoctorId",
                table: "MedicalConsultation",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalConsultation_MedicalConsultationStatusId",
                table: "MedicalConsultation",
                column: "MedicalConsultationStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalConsultation_MedicalSpecialtyId",
                table: "MedicalConsultation",
                column: "MedicalSpecialtyId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalConsultation_PatientId",
                table: "MedicalConsultation",
                column: "PatientId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MedicalConsultation");

            migrationBuilder.DropTable(
                name: "Doctor");

            migrationBuilder.DropTable(
                name: "Patient");

            migrationBuilder.DropTable(
                name: "StatusConsulta");

            migrationBuilder.DropTable(
                name: "MedicalSpecialty");
        }
    }
}
