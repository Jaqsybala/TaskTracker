using Microsoft.AspNetCore.Mvc;
using TaskTracker.DataAccess.Models;
using TaskTracker.Logic.Interfaces;
using TaskTracker.Logic.ViewModels;

namespace TaskTracker.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssignmentController : ControllerBase
    {
        private readonly IAssignmentManager _assignmentManager;

        public AssignmentController(IAssignmentManager assignment)
        { 
            _assignmentManager = assignment;
        }

        [HttpPost("Create")]
        public int Create([FromBody] CreateAssignmentVM assignment)
        {
            return _assignmentManager.CreateTask(assignment);
        }

        [HttpGet("GetAll")]
        public List<GetAssignmentsVM> GetAll()
        { 
            return _assignmentManager.GetAllTasks();
        }

        [HttpGet("GetById")]
        public GetAssignmentByIdVM GetById(int id)
        { 
            return _assignmentManager.GetOneTaskById(id);
        }

        [HttpPut("UpdateTask")]
        public int Update(UpdateAssignmentVM updateAssignment)
        { 
            return _assignmentManager.UpdateTask(updateAssignment);
        }

        [HttpPut("UpdateStatus")]
        public int UpdateStatus(int id)
        {
            return _assignmentManager.UpdateStatus(id);
        }

        [HttpDelete("Delete")]
        public void Delete(int id)
        { 
            _assignmentManager.DeleteTask(id);
        }
    }
}
