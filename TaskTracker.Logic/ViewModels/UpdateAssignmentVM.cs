using TaskTracker.DataAccess.Enums;

namespace TaskTracker.Logic.ViewModels
{
    public class UpdateAssignmentVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public AssignmentPriority Priority { get; set; }
        public AssignmentStatus Status { get; set; }
    }
}
