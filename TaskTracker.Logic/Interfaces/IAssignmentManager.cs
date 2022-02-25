using TaskTracker.DataAccess.Models;
using TaskTracker.Logic.ViewModels;

namespace TaskTracker.Logic.Interfaces
{
    public interface IAssignmentManager
    {
        List<GetAssignmentsVM> GetAllTasks();
        int CreateTask(CreateAssignmentVM createAssignmentVm);
        int UpdateTask(UpdateAssignmentVM updateAssignmentVm);
        int UpdateStatus(int id);
        void DeleteTask(int id);
        GetAssignmentByIdVM GetOneTaskById(int id);
    }    
}
