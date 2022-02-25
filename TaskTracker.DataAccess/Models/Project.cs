using TaskTracker.DataAccess.Enums;

namespace TaskTracker.DataAccess.Models
{
    public class Project
    {
        public int Id { get; set; }
        public string ProjectName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public ProjectPriority Priority { get; set; }
        public ProjectStatus Status { get; set; }
        public virtual List<Assignment> Assignments { get; set; }
    }
}
