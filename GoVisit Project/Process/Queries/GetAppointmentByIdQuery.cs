namespace GoVisit_Project.Process.Queries
{
    public class GetAppointmentByIdQuery
    {
        public long Id { get; }
        public GetAppointmentByIdQuery(long id) => Id = id;
    }
}
