using System.Reflection;
using AgendaMedica.Context;
using AgendaMedica.Interfaces;
using AgendaMedica.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

string sqlConnection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(sqlConnection));

builder.Services.AddScoped<IDoctorDapperRepository, DoctorDapperRepository>();
builder.Services.AddScoped<IPatientDapperRepository, PatientDapperRepository>();

//builder.Services.AddMediatR(typeof(Program).Assembly);
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());


builder.Services.AddScoped<IMedicalConsultationRepository, MedicalConsultationRepository>();
builder.Services.AddScoped<IMedicalConsultationStatusRepository, MedicalConsultationStatusRepository>();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
