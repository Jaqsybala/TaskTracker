using TaskTracker.DataAccess.Enums;

namespace TaskTracker.Logic.ViewModels
{
    public class CreateAssignmentVM
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public AssignmentPriority Priority { get; set; }
        public AssignmentStatus Status { get; set; }
        public int ProjectId { get; set; }
    }
}
