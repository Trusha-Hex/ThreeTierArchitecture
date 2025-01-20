using Microsoft.AspNetCore.Mvc;
using ThreeTierApp.DAL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using ThreeTierApp.Core.Interfaces;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using ThreeTierApp.Web.Models;
using System.Security.Claims;
using System;
using Microsoft.AspNetCore.Authorization;
using System.Linq;
using ThreeTierApp.Core.Services;
using Microsoft.Extensions.Logging;

namespace ThreeTierApp.Web.Controllers
{
    [Controller]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;
        private readonly TaskDetailsService _service;
        private readonly ILogger<EmployeeController> _logger; // Inject logger

        public EmployeeController(IEmployeeService employeeService, TaskDetailsService service, ILogger<EmployeeController> logger)
        {
            _employeeService = employeeService;
            _service = service;
            _logger = logger; // Assign logger
        }

        [AllowAnonymous]
        public IActionResult Login()
        {
            _logger.LogInformation("Login page accessed.");
            return View();
        }

        [Authorize]
        public IActionResult Index()
        {
            _logger.LogInformation("Index page accessed by user {User}.", User.Identity.Name);
            return View();
        }

        // Get All Employees (only Admin can access)
        [HttpGet("employees")]
        [Authorize]
        public async Task<ActionResult<IEnumerable<Employee>>> GetAllEmployees()
        {
            try
            {
                _logger.LogInformation("Attempting to fetch all employees.");
                var loggedInUserId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
                var userRole = User.FindFirstValue(ClaimTypes.Role);

                var employees = await _employeeService.GetAllEmployeesAsync();
                _logger.LogInformation("Employees fetched successfully for user {User}.", loggedInUserId);

                if (userRole == "Admin")
                {
                    return Ok(employees);
                }

                if (userRole == "Manager")
                {
                    var filteredEmployees = employees.Where(e => e.Role != "Admin").ToList();
                    return Ok(filteredEmployees);
                }

                if (userRole == "Employee")
                {
                    var employee = employees.FirstOrDefault(e => e.Id == loggedInUserId);
                    if (employee != null)
                    {
                        return Ok(new List<Employee> { employee });
                    }

                    _logger.LogWarning("Employee not found for ID {EmployeeId}.", loggedInUserId);
                    return NotFound(new { message = "Employee not found" });
                }

                return Unauthorized(new { message = "Unauthorized role" });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while retrieving employees.");
                return BadRequest(new { message = "Error retrieving employees." });
            }
        }


        [HttpGet("employees/{id}")]
        //[Authorize]
        public async Task<ActionResult<Employee>> GetEmployeeById(int id)
        {
            try
            {
                var employee = await _employeeService.GetEmployeeByIdAsync(id);
                if (employee == null)
                {
                    return NotFound(new { message = "Employee not found" });
                }
                return Ok(employee);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = $"Error retrieving employee: {ex.Message}" });
            }
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginModel loginModel)
        {
            try
            {
                if (string.IsNullOrEmpty(loginModel.EmailOrUsername) || string.IsNullOrEmpty(loginModel.Password))
                {
                    return BadRequest(new { message = "Email/Username and Password are required." });
                }

                var employee = await _employeeService.GetEmployeeByEmailOrUsernameAsync(loginModel.EmailOrUsername);
                if (employee == null)
                {
                    return Unauthorized(new { message = "Invalid credentials." });
                }

                var hashedPassword = HashPassword(loginModel.Password);

                if (employee.PasswordHash != hashedPassword)
                {
                    return Unauthorized(new { message = "Invalid credentials." });
                }

                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, employee.Id.ToString()),
                    new Claim(ClaimTypes.Name, employee.Name),
                    new Claim(ClaimTypes.Email, employee.Email),
                    new Claim(ClaimTypes.Role, employee.Role ?? "Employee")
                };

                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                return Ok(new { message = "Login successful.", redirectUrl = "/Employee/Index" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = $"Error during login: {ex.Message}" });
            }
        }

        private string HashPassword(string password)
        {
            return Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(password));
        }

        [HttpPost("employees")]
        [Authorize]
        public async Task<ActionResult<Employee>> AddEmployee([FromBody] Employee employee)
        {
            if (employee == null)
            {
                return BadRequest(new { message = "Employee data is required." });
            }

            var userRole = User.FindFirstValue(ClaimTypes.Role);

            // Admin: Can add any employee
            if (userRole == "Admin")
            {
                var result = await _employeeService.AddEmployeeAsync(employee);
                if (result != null)
                {
                    return BadRequest(new { message = result });
                }

                return CreatedAtAction(nameof(GetEmployeeById), new { id = employee.Id }, employee);
            }

            // Manager/Employee: Cannot add employees
            return Unauthorized(new { message = "You do not have permission to add employees." });
        }



        [HttpPut("employees/{id}")]
        [Authorize]
        public async Task<IActionResult> UpdateEmployeeAsync(int id, [FromBody] Employee employee)
        {
            try
            {
                var loggedInUserId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
                var userRole = User.FindFirstValue(ClaimTypes.Role);

                // Ensure the employee ID matches the URL parameter
                if (id != employee.Id)
                {
                    return BadRequest(new { message = "Employee ID mismatch" });
                }

                // Admin: Can update any employee
                if (userRole == "Admin")
                {
                    var validationResult = await _employeeService.UpdateEmployeeAsync(employee);
                    if (validationResult != null)
                    {
                        return BadRequest(validationResult);
                    }
                    return NoContent();
                }

                // Manager: Can update any employee except Admins
                if (userRole == "Manager" && employee.Role != "Admin")
                {
                    var validationResult = await _employeeService.UpdateEmployeeAsync(employee);
                    if (validationResult != null)
                    {
                        return BadRequest(validationResult);
                    }
                    return NoContent();
                }

                // Employee: Can only update their own record
                if (userRole == "Employee" && employee.Id == loggedInUserId)
                {
                    var validationResult = await _employeeService.UpdateEmployeeAsync(employee);
                    if (validationResult != null)
                    {
                        return BadRequest(validationResult);
                    }
                    return NoContent();
                }

                return Unauthorized(new { message = "You do not have permission to update this employee" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = $"Error updating employee: {ex.Message}" });
            }
        }

        [HttpDelete("employees/{id}")]
        [Authorize]
        public async Task<ActionResult> DeleteEmployee(int id)
        {
            try
            {
                var loggedInUserId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
                var userRole = User.FindFirstValue(ClaimTypes.Role);

                // Admin: Can delete any employee
                if (userRole == "Admin")
                {
                    await _employeeService.DeleteEmployeeAsync(id);
                    return NoContent();
                }

                // Manager/Employee: Cannot delete any employee
                if (userRole == "Manager" || userRole == "Employee")
                {
                    return Unauthorized(new { message = "You do not have permission to delete employees" });
                }

                return NotFound(new { message = "Employee not found" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = $"Error deleting employee: {ex.Message}" });
            }
        }

        [HttpPut("update-status/{employeeId}")]
        [Authorize]
        public async Task<IActionResult> UpdateStatus(int employeeId, [FromQuery] string isActive)
        {
            Console.WriteLine($"Received isActive: {isActive}"); // Debug log

            if (employeeId <= 0)
            {
                return BadRequest("Invalid employee ID.");
            }

            // Validate the isActive query parameter
            if (string.IsNullOrEmpty(isActive))
            {
                return BadRequest("isActive is required in the query parameters.");
            }

            // Convert the string to boolean (true or false)
            bool isActiveBool;
            if (!bool.TryParse(isActive, out isActiveBool))
            {
                return BadRequest("Invalid value for 'isActive'. Must be 'true' or 'false'.");
            }

            var result = await _employeeService.UpdateStatusAsync(employeeId, isActiveBool);

            if (result)
                return Ok(new { message = "Employee status updated successfully." });

            return NotFound(new { message = "Employee not found." });
        }

        [HttpPost("logout")]
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            try
            {
                await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
                return Ok(new { message = "Logout successful.", redirectUrl = "/Employee/Login" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = $"Error during logout: {ex.Message}" });
            }
        }

        [HttpGet("employees/{employeeId}/tasks")]
        public async Task<ActionResult<IEnumerable<TaskDetails>>> GetTasksForEmployee(int employeeId)
        {
            try
            {
                // Ensure the logged-in employee ID matches the requested employee ID (for Employee role).
                //var loggedInUserId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
                //var userRole = User.FindFirstValue(ClaimTypes.Role);

                // If the logged-in user is not an Admin and is not the same as the requested employee, return unauthorized
                //if (userRole != "Admin" && loggedInUserId != employeeId)
                //{
                //    return Unauthorized(new { message = "You do not have permission to view these tasks." });
                //}

                // Fetch all tasks and filter by the employee ID
                var tasks = await _service.GetAllTasksAsync(); // Assuming this service fetches all tasks

                if (tasks == null || !tasks.Any())  // Check for null or empty task list
                {
                    return NotFound(new { message = "No tasks found for the employee." });
                }

                var employeeTasks = tasks.Where(t => t.AssignedEmployeeIds != null && t.AssignedEmployeeIds.Contains(employeeId)).ToList();

                if (!employeeTasks.Any())
                {
                    return NotFound(new { message = "No tasks found for the employee." });
                }

                return Ok(employeeTasks);
            }
            catch (Exception ex)
            {
                // Log the error for better visibility
                Console.WriteLine($"Error: {ex.Message}");
                Console.WriteLine($"Stack Trace: {ex.StackTrace}");
                return BadRequest(new { message = $"Error retrieving tasks: {ex.Message}" });
            }
        }



    }
}
