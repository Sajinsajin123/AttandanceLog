namespace AttandanceTracker.Domain.RepoInterface
{
    public class Attandance
    {
        public int AttendanceID { get; set; }

        public int UserId { get; set; }

        public DateTime Date { get; set; }

        public string Status { get; set; }

        public string Course { get; set; }

        public int RecordedBy { get; set; }
    }
}