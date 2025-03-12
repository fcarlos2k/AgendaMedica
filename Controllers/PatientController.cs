using AgendaMedica.Commands.Patients;
using AgendaMedica.Models;
using AgendaMedica.Queries.Patients;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AgendaMedica.Controllers;

[Route("[controller]")]
[ApiController]
public class PatientController : ControllerBase
{
    private readonly IMediator _mediator;

    public PatientController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Patient>>> GetPatients()
    {
        var patients = await _mediator.Send(new GetPatientsQuery());
        return Ok(patients);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Patient>> GetPatientById(int id)
    {
        var patient = await _mediator.Send(new GetPatientByIdQuery(id));
        if (patient == null)
        {
            return NotFound();
        }
        return Ok(patient);
    }

    [HttpPost]
    public async Task<ActionResult<Patient>> AddPatient(CreatePatientCommand command)
    {
        if (command == null)
        {
            return BadRequest();
        }

        var patient = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetPatientById), new { id = patient.Id }, patient);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdatePatient(int id, UpdatePatientCommand command)
    {
        if (id != command.Id)
        {
            return BadRequest();
        }

        var existingPatient = await _mediator.Send(new GetPatientByIdQuery(id));
        if (existingPatient == null)
        {
            return NotFound();
        }

        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePatient(int id)
    {
        var patient = await _mediator.Send(new GetPatientByIdQuery(id));
        if (patient == null)
        {
            return NotFound();
        }

        await _mediator.Send(new DeletePatientCommand(id));
        return NoContent();
    }
}