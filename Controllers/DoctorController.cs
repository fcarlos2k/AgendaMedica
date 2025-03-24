using AgendaMedica.Commands.Doctors;
using AgendaMedica.Queries.Doctors;
using AgendaMedica.Queries.MedicalConsultations;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AgendaMedica.Controllers;

[Route("[controller]")]
[ApiController]
public class DoctorController : ControllerBase
{
    private readonly IMediator _mediator;

    public DoctorController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetDoctors()
    {
        var query = new GetDoctorsQuery();
        var doctors = await _mediator.Send(query);
        return Ok(doctors);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetDoctorById(int id)
    {
        var query = new GetDoctorByIdQuery(id);

        var doctor = await _mediator.Send(query);

        if (doctor == null)
        {
            return NotFound();
        }
        return Ok(doctor);
    }

    [HttpGet("BySpecialty/{specialtyId}")]
    public async Task<IActionResult> GetDoctorsBySpecialty(int specialtyId)
    {
        var query = new GetDoctorsBySpecialty(specialtyId);
        var doctors = await _mediator.Send(query);
        return Ok(doctors);
    }

    [HttpPost]
    public async Task<IActionResult> AddDoctor(CreateDoctorCommand command)
    {
        if (command == null)
        {
            return BadRequest();
        }

        var doctor = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetDoctorById), new { id = doctor.Id }, doctor);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateDoctor(int id, UpdateDoctorCommand command)
    {
        if (id != command.Id)
        {
            return BadRequest();
        }

        var existingDoctor = await _mediator.Send(new GetDoctorByIdQuery(id));
        if (existingDoctor == null)
        {
            return NotFound();
        }

        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteDoctor(int id)
    {
        var doctor = await _mediator.Send(new GetDoctorByIdQuery(id));
        if (doctor == null)
        {
            return NotFound();
        }

        await _mediator.Send(new DeleteDoctorCommand(id));
        return NoContent();
    }
}