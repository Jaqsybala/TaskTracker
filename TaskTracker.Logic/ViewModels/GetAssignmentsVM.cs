using TaskTracker.DataAccess.Enums;

namespace TaskTracker.Logic.ViewModels
{
    public class GetAssignmentsVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public AssignmentPriority Priority { get; set; }
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
    }
}
