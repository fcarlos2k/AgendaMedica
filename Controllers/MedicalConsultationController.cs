using AgendaMedica.Commands.MedicalConsultations;
using AgendaMedica.Queries.MedicalConsultations;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AgendaMedica.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MedicalConsultationController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MedicalConsultationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("schedule")]
        public async Task<IActionResult> ScheduleConsultation(ScheduleMedicalConsultationCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPost("confirm")]
        public async Task<IActionResult> ConfirmConsultation(ConfirmMedicalConsultationCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPost("cancel")]
        public async Task<IActionResult> CancelConsultation(CancelMedicalConsultationCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpGet("agenda")]
        public async Task<IActionResult> GetAgenda([FromQuery] GetAgendaQuery query)
        {
            var result = await _mediator.Send(query);
            return Ok(result);
        }
    }
}
