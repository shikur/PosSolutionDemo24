using Microsoft.AspNetCore.Mvc;
using pos.domain.model;
using pos.services;
using pos.services.Interface;
using System.Collections.Generic;

namespace pos.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly ILogger<EmployeeController> _logger;
        private readonly IEmployeesService _employeeService;

        /// <summary>
        /// Initializes a new instance of the <see cref="EmployeeController"/> class.
        /// </summary>
        /// <param name="logger">The logger instance to log information.</param>
        /// <param name="employeeService">The employee service to manage employee data.</param>
        public EmployeeController(ILogger<EmployeeController> logger, IEmployeesService employeeService)
        {
            this._logger = logger;
            this._employeeService = employeeService;
            logger.LogInformation("**********EmployeeController constructor!**************");
        }

        /// <summary>
        /// Retrieves a list of all employees.
        /// </summary>
        /// <returns>
        /// A list of employee objects. Returns a 200 OK response with the list of employees,
        /// or a 500 Internal Server Error if an exception occurs.
        /// </returns>
        /// <remarks>
        /// This method retrieves all employees by calling the employee service asynchronously.
        /// </remarks>
        /// <response code="200">List of employees successfully retrieved.</response>
        /// <response code="500">Internal server error occurred while retrieving employees.</response>
        [HttpGet]
        public async Task<IActionResult> GetAllEmployees()
        {
            try
            {
                IEnumerable<Employee> employees = await this._employeeService.GetAllEmployeesAsync();
                this._logger.LogInformation("Successfully retrieved all employee list!");
                return Ok(employees.ToList());
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "Internal server error: " + ex.Message);
            }
        }

        /// <summary>
        /// Retrieves a specific employee by ID.
        /// </summary>
        /// <param name="id">The ID of the employee to retrieve.</param>
        /// <returns>
        /// Returns a 200 OK response with the employee details, a 400 Bad Request if the ID is invalid,
        /// or a 500 Internal Server Error if an exception occurs.
        /// </returns>
        /// <response code="200">Employee details successfully retrieved.</response>
        /// <response code="400">Invalid employee ID provided.</response>
        /// <response code="500">Internal server error occurred while retrieving employee.</response>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployeeById(int id)
        {
            if (id < 0)
            {
                return BadRequest("Error: Invalid request with internal server.");
            }

            try
            {
                var employee = await this._employeeService.GetEmployeesByIdAsync(id);
                return Ok(employee);
            }
            catch (Exception ex)
            {
                this._logger.LogInformation("Error: Unable to retrieve data!");
                return StatusCode(500, "Internal server error: " + ex.Message);
            }
        }

        /// <summary>
        /// Saves a new employee record to the system.
        /// </summary>
        /// <param name="employee">The employee object to be saved.</param>
        /// <returns>
        /// Returns a 201 Created response if the save operation is successful, or an error response if the save fails.
        /// </returns>
        /// <response code="201">Employee successfully created.</response>
        /// <response code="400">Employee data is null or invalid.</response>
        /// <response code="500">Internal server error occurred during the save process.</response>
        [HttpPost]
        public async Task<IActionResult> Save([FromBody] Employee employee)
        {
            if (employee == null)
            {
                this._logger.LogInformation("It was trying to save employee data!");
                return BadRequest("Employee data is null.");
            }

            try
            {
                // Call service to add the employee
                await _employeeService.AddEmployeeAsync(employee);

                // Return success response (e.g., 201 Created)
                return CreatedAtAction(nameof(GetEmployeeById), new { id = employee.Emp_ID }, employee);
            }
            catch (Exception ex)
            {
                this._logger.LogInformation("Error: Unable to save employee record!");
                return StatusCode(500, "Internal server error: " + ex.Message);
            }
        }

        /// <summary>
        /// Deletes a specific employee by ID.
        /// </summary>
        /// <param name="id">The ID of the employee to delete.</param>
        /// <returns>
        /// Returns a 200 OK response if the employee is successfully deleted,
        /// or a 500 Internal Server Error if an exception occurs.
        /// </returns>
        /// <response code="200">Employee successfully deleted.</response>
        /// <response code="500">Internal server error occurred during the delete process.</response>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployeeById(int id = 1)
        {
            try
            {
                await this._employeeService.DeleteEmployeesAsync(id);
                this._logger.LogInformation("Deleted successfully!!");
                return Ok("Deleted successfully!");
            }
            catch (Exception ex)
            {
                this._logger.LogInformation("Error: Unable to retrieve data!");
                return StatusCode(500, "Internal server error: " + ex.Message);
            }
        }
    }
}
