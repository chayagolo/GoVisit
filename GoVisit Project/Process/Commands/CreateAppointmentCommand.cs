using GoVisit_Project.Models;

namespace GoVisit_Project.Process.Commands
{
    public class CreateAppointmentCommand
    {
        public AppointmentModel Appointment { get; }
        public CreateAppointmentCommand(AppointmentModel appointment) => Appointment = appointment;
    }
}
