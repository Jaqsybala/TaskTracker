using System.ComponentModel.DataAnnotations;
using TaskTracker.DataAccess.Enums;

namespace TaskTracker.Logic.ViewModels
{
    public class CreateProjectVM
    {
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public ProjectStatus projectStatus { get; set; }
        public ProjectPriority Priority { get; set; }
    }
}
