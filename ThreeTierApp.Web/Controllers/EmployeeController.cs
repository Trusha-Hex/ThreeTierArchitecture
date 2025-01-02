using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ThreeTierApp.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using ThreeTierApp.Core.Interfaces;
using System;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;
using ThreeTierApp.Web.Models; 
using System.Text.RegularExpressions;
using System.Linq;

namespace ThreeTierApp.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;
        private readonly UserManager<Employee> _userManager;
        private readonly SignInManager<Employee> _signInManager;
        private readonly IConfiguration _configuration;

        // Constructor to inject services
        public EmployeeController(
            IEmployeeService employeeService,
            UserManager<Employee> userManager,
            SignInManager<Employee> signInManager,
            IConfiguration configuration)
        {
            _employeeService = employeeService;
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
        }

        public IActionResult Login()
        {
            return View(); // Ensure Login.cshtml exists in Views/Account/
        }

        // Get all employees
        [HttpGet("employees")]
        public async Task<ActionResult<IEnumerable<Employee>>> GetAllEmployees()
        {
            try
            {
                var employees = await _employeeService.GetAllEmployeesAsync();
                return Ok(employees);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = $"Error retrieving employees: {ex.Message}" });
            }
        }

        // Get employee by ID
        [HttpGet("employees/{id}")]
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


        // Login API (JWT Token)
        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync(LoginModel model)
        {
            // Check if input is an email or username
            var user = await FindUserAsync(model.EmailOrUsername);

            if (user == null)
            {
                return BadRequest(new { message = "Invalid login attempt." });
            }

            var result = await _signInManager.PasswordSignInAsync(user, model.Password, false, false);

            if (result.Succeeded)
            {
                return Ok(new { message = "Login successful" });
            }

            return BadRequest(new { message = "Invalid password" });
        }

        private async Task<Employee> FindUserAsync(string emailOrUsername)
        {
            // Check if input is a valid email
            if (IsValidEmail(emailOrUsername))
            {
                return await _userManager.FindByEmailAsync(emailOrUsername);  
            }
            else
            {
                return await _userManager.FindByNameAsync(emailOrUsername); 
            }
        }

        private bool IsValidEmail(string email)
        {
            var emailRegex = new Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$");
            return emailRegex.IsMatch(email);
        }

        // Signup API
        [HttpPost("register")]
        public async Task<IActionResult> RegisterAsync(RegisterModel model)
        {
            if (model.Password != model.ConfirmPassword)
            {
                return BadRequest(new { message = "Passwords do not match" });
            }

            var employee = new Employee
            {
                UserName = model.Username,
                Email = model.Email,
                Name = model.Name,
                Department = model.Department,
                Salary = model.Salary,
                Role = model.Role,
            };

            var result = await _userManager.CreateAsync(employee, model.Password);

            if (result.Succeeded)
            {
                return Ok(new { message = "Employee registered successfully" });
            }

            return BadRequest(new { message = string.Join(", ", result.Errors.Select(e => e.Description)) });
        }

        // Get employee by username
        [HttpGet("employees/username/{username}")]
        public async Task<ActionResult<Employee>> GetEmployeeByUsername(string username)
        {
            try
            {
                var employee = await _employeeService.GetEmployeeByUsernameAsync(username);
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

        // Get employees by role
        [HttpGet("employees/role/{role}")]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployeesByRole(string role)
        {
            try
            {
                var employees = await _employeeService.GetEmployeesByRoleAsync(role);
                return Ok(employees);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = $"Error retrieving employees by role: {ex.Message}" });
            }
        }

        // Add new employee
        [HttpPost("employees")]
        public async Task<ActionResult<Employee>> AddEmployee(Employee employee)
        {
            try
            {
                var validationResult = await _employeeService.AddEmployeeAsync(employee);

                if (validationResult != null) // Validation failed
                {
                    return BadRequest(validationResult);  // Return validation errors
                }

                return CreatedAtAction(nameof(GetEmployeeById), new { id = employee.Id }, employee);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = $"Error adding employee: {ex.Message}" });
            }
        }

        // Update employee
        [HttpPut("employees/{id}")]
        public async Task<IActionResult> UpdateEmployeeAsync(int id, [FromBody] Employee employee)
        {
            try
            {
                // Ensure the ID in the URL matches the ID in the request body
                if (id != employee.Id)
                {
                    return BadRequest(new { message = "Employee ID mismatch" });
                }

                var validationResult = await _employeeService.UpdateEmployeeAsync(employee);

                if (validationResult != null) // Validation failed
                {
                    return BadRequest(validationResult);  // Return validation errors
                }

                return NoContent();  // Successfully updated
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = $"Error updating employee: {ex.Message}" });
            }
        }

        // Delete employee
        [HttpDelete("employees/{id}")]
        public async Task<ActionResult> DeleteEmployee(int id)
        {
            try
            {
                await _employeeService.DeleteEmployeeAsync(id);
                return NoContent();  // Successfully deleted
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = $"Error deleting employee: {ex.Message}" });
            }
        }

        // Get all active employees
        [HttpGet("employees/active")]
        public async Task<ActionResult<IEnumerable<Employee>>> GetActiveEmployees()
        {
            try
            {
                var employees = await _employeeService.GetActiveEmployeesAsync();
                return Ok(employees);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = $"Error retrieving active employees: {ex.Message}" });
            }
        }

        // Change employee status
        [HttpPatch("employees/{id}/status")]
        public async Task<IActionResult> ChangeEmployeeStatus(int id, [FromBody] bool isActive)
        {
            try
            {
                var result = await _employeeService.ChangeEmployeeStatusAsync(id, isActive);
                if (!result)
                {
                    return NotFound(new { message = "Employee not found or status update failed" });
                }

                return Ok(new { message = "Employee status updated successfully" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = $"Error changing employee status: {ex.Message}" });
            }
        }
    }
}
