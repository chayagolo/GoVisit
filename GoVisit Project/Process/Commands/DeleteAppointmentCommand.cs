namespace GoVisit_Project.Process.Commands
{
    public class DeleteAppointmentCommand
    {
        public long Id { get; }
        public DeleteAppointmentCommand(long id) => Id = id;
    }
}
