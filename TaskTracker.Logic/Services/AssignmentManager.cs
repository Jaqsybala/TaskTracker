using Microsoft.EntityFrameworkCore;
using TaskTracker.DataAccess;
using TaskTracker.DataAccess.Enums;
using TaskTracker.DataAccess.Models;
using TaskTracker.Logic.Exceptions;
using TaskTracker.Logic.Interfaces;
using TaskTracker.Logic.ViewModels;

namespace TaskTracker.Logic.Services
{
    public class AssignmentManager : IAssignmentManager
    {
        private readonly DatabaseContext _databaseContext;
        public AssignmentManager(DatabaseContext context)
        {
            _databaseContext = context;
        }
        public int CreateTask(CreateAssignmentVM createAssignment)
        {
            var project = _databaseContext.Projects.Find(createAssignment.ProjectId) ??
                            throw new NotFoundException(nameof(Project), createAssignment.ProjectId);

            var assignment = new Assignment
            {
                Name = createAssignment.Name,
                Description = createAssignment.Description,
                Status = DataAccess.Enums.AssignmentStatus.ToDo,
                Priority = createAssignment.Priority,
                Project = project
            };

            _databaseContext.Add(assignment);
            _databaseContext.SaveChanges();

            return assignment.Id;
        }

        public void DeleteTask(int id)
        {
            var assignment = _databaseContext.Assignments.Find(id) ??
                            throw new NotFoundException(nameof(Assignment), id);

            if (assignment != null)
            {
                _databaseContext.Assignments.Remove(assignment);
                _databaseContext.SaveChanges();
            }
        }

        public List<GetAssignmentsVM> GetAllTasksByProjectId(int projectId)
        {
            var list = _databaseContext.Assignments.Where(x => x.Project.Id == projectId)
               .Select(x => new GetAssignmentsVM
               {
                   Id = x.Id,
                   Name = x.Name,
                   Description = x.Description,
                   Priority = x.Priority,
                   ProjectId = x.Project.Id,
                   ProjectName = x.Project.ProjectName
               }).ToList();
            return list;
        }

        public List<GetAssignmentsVM> GetAllTasks()
        {
            var list = _databaseContext.Assignments.Select(x => new GetAssignmentsVM
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                Priority = x.Priority,
                ProjectId = x.Project.Id,
                ProjectName = x.Project.ProjectName
            }).ToList();
            return list;
        }

        public GetAssignmentByIdVM GetOneTaskById(int id)
        {
            var assignment = _databaseContext.Assignments.Find(id) ??
                            throw new NotFoundException(nameof(Assignment), id);
            var res = new GetAssignmentByIdVM
            {
                Id = assignment.Id,
                Name = assignment.Name,
                Description = assignment.Description,
                Priority = assignment.Priority,
                Status = assignment.Status,
                ProjectName = assignment.Project.ProjectName
            };
            return res;
        }

        public int UpdateTask(UpdateAssignmentVM updateAssignmentVm)
        {
            var assignment = _databaseContext.Assignments.Find(updateAssignmentVm.Id) ??
                            throw new NotFoundException(nameof(Assignment), updateAssignmentVm.Id);
            if (assignment != null)
            {
                assignment.Name = updateAssignmentVm.Name;
                assignment.Description = updateAssignmentVm.Description;
                assignment.Priority = updateAssignmentVm.Priority;
                assignment.Status = AssignmentStatus.InProgress;
                _databaseContext.SaveChanges();
            }
            return assignment.Id;
        }

        public int UpdateStatus(int id)
        {
            var asssingment = _databaseContext.Assignments.Find(id) ??
                            throw new NotFoundException(nameof(Assignment), id);
            if (asssingment != null && asssingment.Status == AssignmentStatus.ToDo)
            {
                asssingment.Status = AssignmentStatus.InProgress;
                _databaseContext.SaveChanges();
            }
            else if (asssingment != null && asssingment.Status == AssignmentStatus.InProgress)
            {
                asssingment.Status = AssignmentStatus.Done;
                _databaseContext.SaveChanges();
            }
            return asssingment.Id;
        }

    }
}
