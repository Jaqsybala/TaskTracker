using TaskTracker.DataAccess.Enums;

namespace TaskTracker.Logic.ViewModels
{
    public class GetProjectByIdVM
    {
        public int Id { get; set; }
        public string ProjectName { get; set; }
        public DateTime StartDate { get; set; }
        public ProjectPriority Priority { get; set; }
        public ProjectStatus Status { get; set; }
        public IList<GetAssignmentByIdVM> Assignments { get; set; }
    }
}
