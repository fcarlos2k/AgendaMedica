using AgendaMedica.Commands.MedicalConsultationStatuses;
using AgendaMedica.Queries.MedicalConsultationStatuses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AgendaMedica.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MedicalConsultationStatusController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MedicalConsultationStatusController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetMedicalConsultationStatuss()
        {
            var query = new GetMedicalConsultationStatusesQuery();
            var medicalConsultationStatuss = await _mediator.Send(query);
            return Ok(medicalConsultationStatuss);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMedicalConsultationStatusById(int id)
        {
            var query = new GetMedicalConsultationStatusByIdQuery(id);

            var medicalConsultationStatus = await _mediator.Send(query);

            if (medicalConsultationStatus == null)
            {
                return NotFound();
            }
            return Ok(medicalConsultationStatus);
        }

        [HttpPost]
        public async Task<IActionResult> AddMedicalConsultationStatus(CreateMedicalConsultationStatusCommand command)
        {
            if (command == null)
            {
                return BadRequest();
            }

            var medicalConsultationStatus = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetMedicalConsultationStatusById), new { id = medicalConsultationStatus.Id }, medicalConsultationStatus);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMedicalConsultationStatus(int id, UpdateMedicalConsultationStatusCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            var existingMedicalConsultationStatus = await _mediator.Send(new GetMedicalConsultationStatusByIdQuery(id));
            if (existingMedicalConsultationStatus == null)
            {
                return NotFound();
            }

            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMedicalConsultationStatus(int id)
        {
            var medicalConsultationStatus = await _mediator.Send(new GetMedicalConsultationStatusByIdQuery(id));
            if (medicalConsultationStatus == null)
            {
                return NotFound();
            }

            await _mediator.Send(new DeleteMedicalConsultationStatusCommand(id));
            return NoContent();
        }
    }
}