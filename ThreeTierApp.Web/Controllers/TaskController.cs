using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using ThreeTierApp.Core.Services;
using ThreeTierApp.DAL.Models;
using System.Linq;
using System;
using ThreeTierApp.Core.Interfaces;


namespace ThreeTierApp.Web.Controllers
{
    // [Route("Task")]
    public class TaskController : Controller
    {
        private readonly TaskDetailsService _service;
        private readonly ITaskNotificationService _notificationService;

        public TaskController(TaskDetailsService service, ITaskNotificationService notificationService)
        {
            _service = service;
            _notificationService = notificationService;
        }

        [HttpGet("tasks/")]
        public async Task<IActionResult> GetTasks()
        {
            var tasks = await _service.GetAllTasksAsync();
            if (tasks == null || !tasks.Any())
            {
                return Ok(new { message = "No tasks found.", notification = "Tasks not found in the system." });
            }
            return Ok(new { message = "Tasks fetched successfully.", notification = "Tasks retrieved successfully.", data = tasks });
        }

        // This is the method for rendering tasks in the Index view
        public async Task<IActionResult> Index()
        {
            var tasks = await _service.GetAllTasksAsync();  // Fetch tasks
            return View(tasks);  // Pass the tasks to the view for rendering
        }

        [HttpGet("tasks/{id}")]
        public async Task<ActionResult<TaskDetails>> GetTaskById(int id)
        {
            var taskDetails = await _service.GetTaskByIdAsync(id);
            if (taskDetails == null)
            {
                return NotFound(new { message = "Task not found.", notification = "No task found with the provided ID." });
            }
            return Ok(new { message = "Task details fetched successfully.", notification = "Task details retrieved successfully.", data = taskDetails });
        }

        [HttpPost("tasks/")]
        public async Task<ActionResult> AddTask([FromBody] TaskDetails taskDetails)
        {
            // Check if the taskDetails object is null
            if (taskDetails == null)
            {
                return BadRequest(new { message = "Task data cannot be null.", notification = "Invalid data provided." });
            }

            // Validate that the AssignedEmployeeIds are not null or empty.
            if (taskDetails.AssignedEmployeeIds == null || taskDetails.AssignedEmployeeIds.Count == 0)
            {
                return BadRequest(new { message = "AssignedEmployeeIds cannot be empty.", notification = "Please assign at least one employee to the task." });
            }

            if (taskDetails == null)
            {
                return BadRequest(new { message = "Task data cannot be null.", notification = "Invalid data provided." });
            }

            taskDetails.IsCompleted = taskDetails.IsCompleted;

            // Example validation for employee IDs
            foreach (var employeeId in taskDetails.AssignedEmployeeIds)
            {
                if (employeeId <= 0)  // Replace this with your actual employee validation logic
                {
                    return BadRequest(new { message = $"Invalid employee ID: {employeeId}", notification = "Invalid employee ID provided." });
                }
            }

            // Call the service to add the task.
            await _service.AddTaskAsync(taskDetails);

            return CreatedAtAction(nameof(GetTaskById), new { id = taskDetails.Id }, new { message = "Task created successfully.", notification = "New task has been added to the system.", data = taskDetails });
        }

        [HttpPut("tasks/{id}")]
        public async Task<ActionResult> UpdateTask(int id, [FromBody] TaskDetails taskDetails)
        {
            if (id != taskDetails.Id) return BadRequest(new { message = "Task ID mismatch", notification = "The task ID provided does not match the request." });

            taskDetails.IsCompleted = taskDetails.IsCompleted;

            await _service.UpdateTaskAsync(taskDetails);
            return NoContent();
        }

        [HttpDelete("tasks/{id}")]
        public async Task<ActionResult> DeleteTask(int id)
        {
            await _service.DeleteTaskAsync(id);
            return Ok(new { message = "Task deleted successfully.", notification = "The task has been removed from the system." });
        }

        [HttpPost("tasks/send-overdue-notification/{taskId}")]
        public async Task<IActionResult> SendOverdueNotification(int taskId)
        {
            // Fetch the task details using taskId
            var task = await _service.GetTaskByIdAsync(taskId);
            if (task == null)
            {
                return NotFound(new { message = "Task not found.", notification = "No task found with the provided ID." });
            }

            // Check if the task is overdue
            if (task.DueDate == null || task.DueDate >= DateTime.Now || task.IsCompleted)
            {
                return BadRequest(new { message = "Task is not overdue or already completed.", notification = "The task is not overdue or already completed." });
            }

            // Get employee records based on AssignedEmployeeIds
            var employees = await _service.GetEmployeesByIdsAsync(task.AssignedEmployeeIds);
            if (employees == null || !employees.Any())
            {
                return BadRequest(new { message = "No employees found.", notification = "Could not retrieve employees' emails." });
            }

            // Extract emails from employee records
            var employeeEmails = employees.Select(e => e.Email).ToList();

            // Compose the subject and body for the email
            var subject = $"Task Overdue: {task.Title}";
            var body = $"Dear Employee, \n\nThe task '{task.Title}' is overdue. Please review and take necessary actions. \n\nTask Description: {task.Description}";

            // Send the email notification to the assigned employees
            var emailSent = await _notificationService.SendEmailNotificationAsync(employeeEmails, subject, body);
            if (!emailSent)
            {
                return StatusCode(500, new { message = "Failed to send email notification.", notification = "There was an issue sending the email." });
            }

            return Ok(new { message = "Email notification sent successfully.", notification = "Task overdue notification sent to the assigned employees." });
        }
    }
}

