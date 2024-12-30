using Microsoft.AspNetCore.Mvc;
using ThreeTierApp.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using ThreeTierApp.Core.Interfaces;
using System;

namespace ThreeTierApp.Web.Controllers
{
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
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

        // Add new employee
        [HttpPost("employees")]
        public async Task<ActionResult<Employee>> AddEmployee(Employee employee)
        {
            var validationResult = await _employeeService.AddEmployeeAsync(employee);

            if (validationResult != null) // Validation failed
            {
                return BadRequest(validationResult);  // Return validation errors
            }

            return CreatedAtAction(nameof(GetEmployeeById), new { id = employee.Id }, employee);
        }

        // Update employee by ID
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

                // Retrieve the existing employee from the database
                var existingEmployee = await _employeeService.GetEmployeeByIdAsync(id);
                if (existingEmployee == null)
                {
                    return NotFound(new { message = "Employee not found" });
                }

                // Update the employee properties
                existingEmployee.Name = employee.Name;
                existingEmployee.Department = employee.Department;
                existingEmployee.Salary = employee.Salary;

                // Call the service method to save changes
                await _employeeService.UpdateEmployeeAsync(existingEmployee);

                return NoContent();  // Successfully updated
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = $"Error updating employee: {ex.Message}" });
            }
        }

        // Delete employee by ID
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
    }
}
