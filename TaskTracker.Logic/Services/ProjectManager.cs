using Microsoft.EntityFrameworkCore;
using System.Linq;
using TaskTracker.DataAccess;
using TaskTracker.DataAccess.Enums;
using TaskTracker.DataAccess.Models;
using TaskTracker.Logic.Exceptions;
using TaskTracker.Logic.Interfaces;
using TaskTracker.Logic.ViewModels;
using TaskTracker.Logic.ViewModels.Projects;

namespace TaskTracker.Logic.Services
{
    public class ProjectManager : IProjectManager
    {
        private readonly DatabaseContext _databaseContext;
        public ProjectManager(DatabaseContext context)
        {
            _databaseContext = context;
        }
        public int CreateProject(CreateProjectVM projectVm)
        {
            var newProject = new Project
            {
                StartDate = projectVm.StartDate,
                Status = ProjectStatus.NotStarted,
                Priority = projectVm.Priority,
                ProjectName = projectVm.Name
            };

            _databaseContext.Projects.Add(newProject);
            _databaseContext.SaveChanges();

            return newProject.Id;
        }
        public void DeleteProject(int id)
        {
                var project = _databaseContext.Projects.Find(id) ??
                            throw new NotFoundException(nameof(Project), id);
            if (project != null)
                {
                    _databaseContext.Projects.Remove(project);
                    _databaseContext.SaveChanges();
                }
        }

        public List<GetProjectsVM> GetAllProjects(GetProjectQueryVm filter)
        {
            var query = _databaseContext.Projects.AsQueryable();

            if (!string.IsNullOrEmpty(filter.Name))
            {
                query = query.Where(x => x.ProjectName.ToLower().Contains(filter.Name.ToLower()));
            }
            
            if (filter.Priority.HasValue)
            {
                query = query.Where(x => x.Priority == filter.Priority.Value);
            }

            if (filter.StartDate.HasValue)
            {
                query = query.Where(x => x.StartDate >= filter.StartDate.Value);
            }

            if (filter.EndDate.HasValue)
            {
                query = query.Where(x => x.StartDate <= filter.EndDate.Value);
            }

            var list = query.Select(x => new GetProjectsVM
            {
                Id = x.Id,
                Name = x.ProjectName,
                Priority = x.Priority,
                StartDate = x.StartDate,
            }).ToList();
            return list;
        }

        public GetProjectByIdVM GetProjectById(int id)
        {
            var project = _databaseContext.Projects.Find(id) ??
                            throw new NotFoundException(nameof(Project), id);
            var res = new GetProjectByIdVM
            {
                Id = project.Id,
                ProjectName = project.ProjectName,
                StartDate = project.StartDate,
                Priority = project.Priority,
                Assignments = project.Assignments.Select(x=>new GetAssignmentByIdVM
                {
                    Description = x.Description,   
                    Id = x.Id, 
                    Name = x.Name,
                    Priority= x.Priority,
                    Status = x.Status
                }).ToList()
            };
            return res;
        }

        public int UpdateProject(UpdateProjectVM projectVm)
        {
            var project = _databaseContext.Projects.Find(projectVm.Id) ??
                            throw new NotFoundException(nameof(Project), projectVm.Id);
            if (project != null)
            {
                project.ProjectName = projectVm.ProjectName;
                project.Priority = projectVm.Priority;
                project.EndDate = DateTime.UtcNow;
                _databaseContext.SaveChanges();
            }
            return project.Id;
        }

        public int UpdateStatus(int id)
        {
            var project = _databaseContext.Projects.Find(id) ??
                            throw new NotFoundException(nameof(Project), id);
            if (project != null && project.Status == ProjectStatus.NotStarted)
            {
                project.Status = ProjectStatus.Active;
                _databaseContext.SaveChanges();
            }
            else if (project != null && project.Status == ProjectStatus.Active)
            {
                project.Status = ProjectStatus.Completed;
                _databaseContext.SaveChanges();
            }
            return project.Id;
        }
    }
}
