using Microsoft.AspNetCore.Mvc;
using TaskTracker.Logic.Interfaces;
using TaskTracker.Logic.ViewModels;
using TaskTracker.Logic.ViewModels.Projects;

namespace TaskTracker.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private readonly IProjectManager _projectManager;
        
        public ProjectsController(IProjectManager projectManager)
        {
            _projectManager = projectManager;
        }

        [HttpPost("Create")]
        public int Create([FromBody] CreateProjectVM projectData)
        {
            return _projectManager.CreateProject(projectData);
        }

        [HttpGet("GetAll")]
        public List<GetProjectsVM> GetAll([FromQuery] GetProjectQueryVm query)
        { 
            return _projectManager.GetAllProjects(query);
        }

        [HttpGet("GetById")]
        public GetProjectByIdVM GetById(int id)
        {
            return _projectManager.GetProjectById(id);
        }

        [HttpPut("UpdateProject")]
        public int Update(UpdateProjectVM updateData)
        { 
            return _projectManager.UpdateProject(updateData);
        }

        [HttpPut("UpdateStatus")]
        public int UpdateStatus(int id)
        { 
            return _projectManager.UpdateStatus(id);
        }

        [HttpDelete("Delete")]
        public void Delete(int id)
        {
            _projectManager.DeleteProject(id);
        }
    }
}
