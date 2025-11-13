using GoVisit_Project.Models;
using GoVisit_Project.Process.Commands;
using GoVisit_Project.Process.Handlers;
using GoVisit_Project.Process.Queries;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace GoVisit_Project.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AppointmentController : ControllerBase
    {
        private readonly AppointmentHandlers _handlers;

        public AppointmentController(AppointmentHandlers handlers)
        {
            _handlers = handlers;
        }

        [HttpGet("/GetAppointments")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _handlers.Handle(new GetAllAppointmentsQuery());
            return Ok(result);
        }

        [HttpGet("/GetAppointmentById/{id:long}")]
        public async Task<IActionResult> GetById(long id)
        {
            var result = await _handlers.Handle(new GetAppointmentByIdQuery(id));
            return result is null ? NotFound() : Ok(result);
        }

        [HttpPost("/AddAppointment")]
        public async Task<IActionResult> Create([FromBody] AppointmentModel appointment)
        {
            await _handlers.Handle(new CreateAppointmentCommand(appointment));
            return CreatedAtAction(nameof(GetById), new { id = appointment.Id }, appointment);
        }

        [HttpPut("/UpdateAppointment/{id:long}")]
        public async Task<IActionResult> Update(long id, [FromBody] AppointmentModel appointment)
        {
            await _handlers.Handle(new UpdateAppointmentCommand(id, appointment));
            return Ok(appointment);
        }

        [HttpDelete("/DeleteAppointment/{id:long}")]
        public async Task<IActionResult> Delete(long id)
        {
            await _handlers.Handle(new DeleteAppointmentCommand(id));
            return NoContent();
        }
    }
}
