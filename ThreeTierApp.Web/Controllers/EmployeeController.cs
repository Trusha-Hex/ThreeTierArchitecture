using Microsoft.AspNetCore.Mvc;
using ThreeTierApp.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using ThreeTierApp.Core.Interfaces;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using ThreeTierApp.Web.Models;
using System.Security.Claims;
using System;

namespace ThreeTierApp.Web.Controllers
{
    [Controller]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Index()
        {
            return View();
        }

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

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel loginModel)
        {
            try
            {
                // Validate if email or username and password are provided
                if (string.IsNullOrEmpty(loginModel.EmailOrUsername) || string.IsNullOrEmpty(loginModel.Password))
                {
                    return BadRequest(new { message = "Email/Username and Password are required." });
                }

                // Fetch employee by email or username using the service
                var employee = await _employeeService.GetEmployeeByEmailOrUsernameAsync(loginModel.EmailOrUsername);
                if (employee == null)
                {
                    return Unauthorized(new { message = "Invalid credentials." });
                }

                // Now use the service's HashPassword method to verify the entered password
                var hashedPassword = HashPassword(loginModel.Password); // Hash the entered password

                // Check if the hashed password matches the stored hash in the database
                if (employee.PasswordHash != hashedPassword)
                {
                    return Unauthorized(new { message = "Invalid credentials." });
                }

                // Create claims for the employee
                var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, employee.Id.ToString()),
            new Claim(ClaimTypes.Name, employee.Name),
            new Claim(ClaimTypes.Email, employee.Email),
            new Claim(ClaimTypes.Role, employee.Role ?? "Employee")
        };

                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);

                // Sign the user in with the cookie authentication
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
        public async Task<ActionResult<Employee>> AddEmployee([FromBody] Employee employee)
        {
            if (employee == null)
            {
                return BadRequest(new { message = "Employee data is required." });
            }

            var result = await _employeeService.AddEmployeeAsync(employee);

            if (result != null)
            {
                return BadRequest(result);
            }

            return CreatedAtAction(nameof(GetEmployeeById), new { id = employee.Id }, employee);
        }

        [HttpPut("employees/{id}")]
        public async Task<IActionResult> UpdateEmployeeAsync(int id, [FromBody] Employee employee)
        {
            try
            {
                if (id != employee.Id)
                {
                    return BadRequest(new { message = "Employee ID mismatch" });
                }

                var validationResult = await _employeeService.UpdateEmployeeAsync(employee);

                if (validationResult != null)
                {
                    return BadRequest(validationResult);
                }

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = $"Error updating employee: {ex.Message}" });
            }
        }

        [HttpDelete("employees/{id}")]
        public async Task<ActionResult> DeleteEmployee(int id)
        {
            try
            {
                await _employeeService.DeleteEmployeeAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = $"Error deleting employee: {ex.Message}" });
            }
        }
    }
}
