using GoVisit_Project.Models;

namespace GoVisit_Project.Process.Commands
{
    public class UpdateAppointmentCommand
    {
        public long Id { get; }
        public AppointmentModel Appointment { get; }

        public UpdateAppointmentCommand(long id, AppointmentModel appointment)
        {
            Id = id;
            Appointment = appointment;
        }
    }
}
