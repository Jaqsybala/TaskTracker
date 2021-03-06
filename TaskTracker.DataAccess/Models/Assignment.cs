using TaskTracker.DataAccess.Enums;

namespace TaskTracker.DataAccess.Models
{
    public class Assignment
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public AssignmentPriority Priority { get; set; }
        public AssignmentStatus Status { get; set; }
        public virtual Project Project { get; set; }
    }
}
