using GoVisit_Project.BusinessLogic.Interfaces;
using GoVisit_Project.Models;

using GoVisit_Project.Process.Commands;
using GoVisit_Project.Process.Queries;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GoVisit_Project.Process.Handlers
{
    public class AppointmentHandlers
    {
        private readonly IAppointmentService _service;

        public AppointmentHandlers(IAppointmentService service)
        {
            _service = service;
        }

        // --- Queries ---
        public async Task<List<AppointmentModel>> Handle(GetAllAppointmentsQuery _) =>
            await _service.GetAllAsync();

        public async Task<AppointmentModel?> Handle(GetAppointmentByIdQuery query) =>
            await _service.GetByIdAsync(query.Id);

        // --- Commands ---
        public async Task Handle(CreateAppointmentCommand command) =>
            await _service.AddAsync(command.Appointment);

        public async Task Handle(UpdateAppointmentCommand command) =>
            await _service.UpdateAsync(command.Id, command.Appointment);

        public async Task Handle(DeleteAppointmentCommand command) =>
            await _service.DeleteAsync(command.Id);
    }
}
