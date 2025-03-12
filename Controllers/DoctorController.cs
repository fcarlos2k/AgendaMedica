using AgendaMedica.Commands.Doctors;
using AgendaMedica.DTOs;
using AgendaMedica.Queries.Doctor;
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
    public async Task<ActionResult<IEnumerable<DoctorDto>>> GetDoctors()
    {
        var doctors = await _mediator.Send(new GetDoctorsQuery());
        return Ok(doctors);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<DoctorDto>> GetDoctorById(int id)
    {
        var doctor = await _mediator.Send(new GetDoctorByIdQuery(id));
        if (doctor == null)
        {
            return NotFound();
        }
        return Ok(doctor);
    }

    [HttpPost]
    public async Task<ActionResult<DoctorDto>> AddDoctor(CreateDoctorCommand command)
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