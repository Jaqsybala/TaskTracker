using TaskTracker.DataAccess.Enums;

namespace TaskTracker.Logic.ViewModels
{
    public class UpdateProjectVM
    {
        public int Id { get; set; }
        public string ProjectName { get; set; }
        public DateTime EndDate { get; set; }
        public ProjectPriority Priority { get; set; }
    }
}
