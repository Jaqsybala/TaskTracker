using TaskTracker.DataAccess.Models;
using TaskTracker.Logic.ViewModels;
using TaskTracker.Logic.ViewModels.Projects;

namespace TaskTracker.Logic.Interfaces
{
    public interface IProjectManager
    {
        int CreateProject(CreateProjectVM projectVm);
        List<GetProjectsVM> GetAllProjects(GetProjectQueryVm query);
        int UpdateProject(UpdateProjectVM updateProjectVm);
        int UpdateStatus(int id);
        void DeleteProject(int id);
        GetProjectByIdVM GetProjectById(int id);
    }
}
