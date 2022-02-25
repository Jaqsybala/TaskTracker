using TaskTracker.DataAccess.Enums;

namespace TaskTracker.Logic.ViewModels.Projects
{
    public class GetProjectQueryVm
    {

        public string? Name { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public ProjectPriority? Priority { get; set; }

    }
}
