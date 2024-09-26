using Microsoft.AspNetCore.Mvc;
using pos.domain.model;
using pos.services.Interface;


namespace pos.api.Controllers
{
    /// <summary>
    /// API controller to handle operations related to Customers.
    /// Provides endpoints to perform CRUD operations on Customer data.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ILogger<CustomerController> _logger;
        private readonly ICustomerService _customerService;

        /// <summary>
        /// Constructor that initializes the logger and customer service.
        /// Logs the initialization of the CustomerController.
        /// </summary>
        /// <param name="logger">Logger for capturing information and errors.</param>
        /// <param name="customerService">Service interface to handle business logic for customers.</param>
        public CustomerController(ILogger<CustomerController> logger, ICustomerService customerService)
        {
            this._logger = logger;
            this._customerService = customerService;

            logger.LogInformation("**********CustomerController constructor!**************");
        }

        /// <summary>
        /// Gets a list of all customers.
        /// </summary>
        /// <returns>A list of all customers in the system.</returns>
        [HttpGet]
        public async Task<IActionResult> GetAllCustomers()
        {
            try
            {
                IEnumerable<Customer> customers = await this._customerService.GetAllCustomersAsync();
                this._logger.LogInformation("Successfully retrieved all customer list!");
                return Ok(customers.ToList());
            }
            catch (Exception ex)
            {
                // Log the exception and return 500 Internal Server Error.
                return StatusCode(500, "Internal server error: " + ex.Message);
            }
        }

        /// <summary>
        /// Gets a specific customer by ID.
        /// </summary>
        /// <param name="id">ID of the customer to retrieve.</param>
        /// <returns>The customer data if found; otherwise, an error response.</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomerById(int id)
        {
            if (id < 0)
            {
                return BadRequest("Invalid customer ID.");
            }

            try
            {
                var customer = await this._customerService.GetCustomersByIdAsync(id);
                return Ok(customer);
            }
            catch (Exception ex)
            {
                this._logger.LogInformation("Error: Unable to retrieve customer data!");
                return StatusCode(500, "Internal server error: " + ex.Message);
            }
        }

        /// <summary>
        /// Saves a new customer to the system.
        /// </summary>
        /// <param name="customer">Customer object to be saved.</param>
        /// <returns>The created customer and its ID in the response.</returns>
        [HttpPost]
        public async Task<IActionResult> Save([FromBody] Customer customer)
        {
            if (customer == null)
            {
                this._logger.LogInformation("Attempted to save null customer data!");
                return BadRequest("Customer data is null.");
            }

            try
            {
                // Call service to add the customer.
                await this._customerService.AddCustomerAsync(customer);
                // Return success response (201 Created).
                return CreatedAtAction(nameof(GetCustomerById), new { id = customer.Cust_ID }, customer);
            }
            catch (Exception ex)
            {
                this._logger.LogInformation("Error: Unable to save customer record!");
                return StatusCode(500, "Internal server error: " + ex.Message);
            }
        }

        /// <summary>
        /// Updates an existing customer's data.
        /// </summary>
        /// <param name="id">ID of the customer to update.</param>
        /// <param name="customer">Updated customer object.</param>
        /// <returns>The updated customer data.</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Customer customer)
        {
            if (customer == null)
            {
                this._logger.LogInformation("Attempted to update null customer data!");
                return BadRequest("Customer data is null.");
            }

            try
            {
                // Call service to update the customer.
                await this._customerService.UpdateCustomerAsync(customer);
                // Return success response (201 Created).
                return CreatedAtAction(nameof(GetCustomerById), new { id = customer.Cust_ID }, customer);
            }
            catch (Exception ex)
            {
                this._logger.LogInformation("Error: Unable to update customer record!");
                return StatusCode(500, "Internal server error: " + ex.Message);
            }
        }

        /// <summary>
        /// Deletes a customer by ID.
        /// </summary>
        /// <param name="id">ID of the customer to delete.</param>
        /// <returns>A success message if the customer was deleted.</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomerById(int id = 1)
        {
            try
            {
                await this._customerService.DeleteCustomersAsync(id);
                this._logger.LogInformation("Customer deleted successfully!");
                return Ok("Deleted successfully!");
            }
            catch (Exception ex)
            {
                this._logger.LogInformation("Error: Unable to delete customer data!");
                return StatusCode(500, "Internal server error: " + ex.Message);
            }
        }
    }
}
