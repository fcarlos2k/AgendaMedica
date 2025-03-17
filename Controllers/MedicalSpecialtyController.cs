using AgendaMedica.Commands.MedicalSpecialties;
using AgendaMedica.Queries.MedicalSpecialties;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AgendaMedica.Controllers;

[Route("[controller]")]
[ApiController]
public class MedicalSpecialtyController : ControllerBase
{
    private readonly IMediator _mediator;

    public MedicalSpecialtyController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetMedicalSpecialties()
    {
        var query = new GetMedicalSpecialtiesQuery();
        var medicalSpecialtys = await _mediator.Send(query);
        return Ok(medicalSpecialtys);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetMedicalSpecialtyById(int id)
    {
        var query = new GetMedicalSpecialtyByIdQuery(id);

        var medicalSpecialty = await _mediator.Send(query);

        if (medicalSpecialty == null)
        {
            return NotFound();
        }
        return Ok(medicalSpecialty);
    }

    [HttpPost]
    public async Task<IActionResult> AddMedicalSpecialty(CreateMedicalSpecialtyCommand command)
    {
        if (command == null)
        {
            return BadRequest();
        }

        var medicalSpecialty = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetMedicalSpecialtyById), new { id = medicalSpecialty.Id }, medicalSpecialty);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateMedicalSpecialty(int id, UpdateMedicalSpecialtyCommand command)
    {
        if (id != command.Id)
        {
            return BadRequest();
        }

        var existingMedicalSpecialty = await _mediator.Send(new GetMedicalSpecialtyByIdQuery(id));
        if (existingMedicalSpecialty == null)
        {
            return NotFound();
        }

        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteMedicalSpecialty(int id)
    {
        var medicalSpecialty = await _mediator.Send(new GetMedicalSpecialtyByIdQuery(id));
        if (medicalSpecialty == null)
        {
            return NotFound();
        }

        await _mediator.Send(new DeleteMedicalSpecialtyCommand(id));
        return NoContent();
    }
}