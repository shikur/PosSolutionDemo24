using Microsoft.AspNetCore.Mvc;
using pos.domain.model;
using pos.services;
using pos.services.Interface;
using System.Collections.Generic;

namespace pos.api.Controllers
{
    /// <summary>
    /// API controller to handle operations related to Orders and Items.
    /// Provides endpoints to perform CRUD operations on Item data.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly ILogger<OrderController> _logger;
        private readonly IItemService _itemService;

        /// <summary>
        /// Constructor that initializes the logger and item service.
        /// Logs the initialization of the OrderController.
        /// </summary>
        /// <param name="logger">Logger for capturing information and errors.</param>
        /// <param name="itemService">Service interface to handle business logic for items.</param>
        public OrderController(ILogger<OrderController> logger, IItemService itemService)
        {
            this._logger = logger;
            _itemService = itemService;
            logger.LogInformation("**********OrderController constructor!**************");
        }

        /// <summary>
        /// Gets a list of all items.
        /// </summary>
        /// <returns>A list of all items in the system.</returns>
        [HttpGet]
        public async Task<IActionResult> GetAllItems()
        {
            try
            {
                IEnumerable<Item> items = await this._itemService.GetAllItemsAsync();
                this._logger.LogInformation("Successfully retrieved all item list!");
                return Ok(items.ToList());
            }
            catch (Exception ex)
            {
                // Log the exception and return 500 Internal Server Error.
                return StatusCode(500, "Internal server error: " + ex.Message);
            }
        }

        /// <summary>
        /// Gets a specific item by ID.
        /// </summary>
        /// <param name="id">ID of the item to retrieve.</param>
        /// <returns>The item data if found; otherwise, an error response.</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetItemsById(int id)
        {
            if (id < 0)
            {
                return BadRequest("Error: Invalid item ID.");
            }

            try
            {
                var item = await this._itemService.GetItemByIdAsync(id);
                return Ok(item);
            }
            catch (Exception ex)
            {
                this._logger.LogInformation("Error: Unable to retrieve item data!");
                return StatusCode(500, "Internal server error: " + ex.Message);
            }
        }

        /// <summary>
        /// Saves a new item to the system.
        /// </summary>
        /// <param name="item">Item object to be saved.</param>
        /// <returns>The created item and its ID in the response.</returns>
        [HttpPost]
        public async Task<IActionResult> Save([FromBody] Item item)
        {
            if (item == null)
            {
                this._logger.LogInformation("Attempted to save null item data!");
                return BadRequest("Item data is null.");
            }

            try
            {
                // Call service to add the item.
                await _itemService.AddItemAsync(item);
                // Return success response (201 Created).
                return CreatedAtAction(nameof(GetItemsById), new { id = item.Items_ID }, item);
            }
            catch (Exception ex)
            {
                this._logger.LogInformation("Error: Unable to save item record!");
                return StatusCode(500, "Internal server error: " + ex.Message);
            }
        }

        /// <summary>
        /// Deletes an item by ID.
        /// </summary>
        /// <param name="id">ID of the item to delete.</param>
        /// <returns>A success message if the item was deleted.</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItemById(int id = 1)
        {
            try
            {
                await this._itemService.DeleteItemsAsync(id);
                this._logger.LogInformation("Item deleted successfully!");
                return Ok("Deleted successfully!");
            }
            catch (Exception ex)
            {
                this._logger.LogInformation("Error: Unable to delete item!");
                return StatusCode(500, "Internal server error: " + ex.Message);
            }
        }
    }
}
