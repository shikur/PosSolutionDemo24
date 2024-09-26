using Microsoft.AspNetCore.Mvc;
using pos.domain.model;
using pos.services;
using pos.services.Interface;
using System.Collections.Generic;

namespace pos.api.Controllers
{
    /// <summary>
    /// API controller to handle operations related to Receipts.
    /// Provides endpoints to perform CRUD operations on Receipt data.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class RecieptController : ControllerBase
    {
        private readonly ILogger<RecieptController> _logger;
        private readonly IRecieptService _recieptService;

        /// <summary>
        /// Constructor that initializes the logger and receipt service.
        /// Logs the initialization of the RecieptController.
        /// </summary>
        /// <param name="logger">Logger for capturing information and errors.</param>
        /// <param name="recieptService">Service interface to handle business logic for receipts.</param>
        public RecieptController(ILogger<RecieptController> logger, IRecieptService recieptService)
        {
            this._logger = logger;
            this._recieptService = recieptService;
            logger.LogInformation("**********RecieptController constructor!**************");
        }

        /// <summary>
        /// Gets a list of all receipts.
        /// </summary>
        /// <returns>A list of all receipts in the system.</returns>
        [HttpGet]
        public async Task<IActionResult> GetAllRecieptAsync()
        {
            try
            {
                IEnumerable<Reciept> reciepts = await this._recieptService.GetAllRecieptAsync();
                this._logger.LogInformation("Successfully retrieved all receipt list!");
                return Ok(reciepts.ToList());
            }
            catch (Exception ex)
            {
                // Log the exception and return 500 Internal Server Error.
                return StatusCode(500, "Internal server error: " + ex.Message);
            }
        }

        /// <summary>
        /// Gets a specific receipt by ID.
        /// </summary>
        /// <param name="id">ID of the receipt to retrieve.</param>
        /// <returns>The receipt data if found; otherwise, an error response.</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetRecieptById(int id)
        {
            if (id < 0)
            {
                return BadRequest("Error: Invalid request.");
            }

            try
            {
                var reciept = await this._recieptService.GetRecieptsByIdAsync(id);
                return Ok(reciept);
            }
            catch (Exception ex)
            {
                this._logger.LogInformation("Error: Unable to retrieve receipt data!");
                return StatusCode(500, "Internal server error: " + ex.Message);
            }
        }

        /// <summary>
        /// Saves a new receipt to the system.
        /// </summary>
        /// <param name="reciept">Receipt object to be saved.</param>
        /// <returns>The created receipt and its ID in the response.</returns>
        [HttpPost]
        public async Task<IActionResult> Save([FromBody] Reciept reciept)
        {
            if (reciept == null)
            {
                this._logger.LogInformation("Attempted to save null receipt data!");
                return BadRequest("Receipt data is null.");
            }

            try
            {
                // Call service to add the receipt.
                await _recieptService.AddRecieptAsync(reciept);
                // Return success response (201 Created).
                return CreatedAtAction(nameof(GetRecieptById), new { id = reciept.Rec_ID }, reciept);
            }
            catch (Exception ex)
            {
                this._logger.LogInformation("Error: Unable to save receipt record!");
                return StatusCode(500, "Internal server error: " + ex.Message);
            }
        }

        /// <summary>
        /// Deletes a receipt by ID.
        /// </summary>
        /// <param name="id">ID of the receipt to delete.</param>
        /// <returns>A success message if the receipt was deleted.</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRecieptById(int id = 1)
        {
            try
            {
                await this._recieptService.DeleteRecieptsAsync(id);
                this._logger.LogInformation("Receipt deleted successfully!");
                return Ok("Deleted successfully!");
            }
            catch (Exception ex)
            {
                this._logger.LogInformation("Error: Unable to delete receipt data!");
                return StatusCode(500, "Internal server error: " + ex.Message);
            }
        }
    }
}
