namespace GoVisit_Project.Models
{
    public class AppointmentModel
    {
        public DateTime AppointmentDate { get; set; }
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string? LastName { get; set; }
        public int AppointmentTypeKod { get; set; }
        public string AppointmentTypeDesc { get; set; }
    }
}
