using CaartingService.API.Data.Interfaces;
using CaartingService.API.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Web.Http.Results;

namespace CaartingService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartingController : ControllerBase
    {

        private readonly ILogger<CartingController> logger;
        private readonly ICartingRepository cartingRepository;

        public CartingController(ICartingRepository cartingRepository, ILogger<CartingController> logger)
        {
            this.cartingRepository = cartingRepository;
            this.logger = logger;
        }

        // GET: api/<CartingController>
        [HttpGet]
        [Route("v1/GetCartInfo/{cartId}")]
        public async Task<IActionResult> GetCartInfo(string cartId)
        {
            if (string.IsNullOrEmpty(cartId))
            {
                return BadRequest("Invalid cart Id");
            }

            try
            {
                var result = await cartingRepository.GetCartInfo(cartId);
                return StatusCode(StatusCodes.Status200OK, result);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);

            }
        }


        // POST api/<CartingController>
        [HttpPost]
        [Route("v1/AddItem")]
        public async Task<IActionResult> AddItem([FromBody] Cart cart)
        {
            try
            {
                await cartingRepository.AddItem(cart);
                return StatusCode(StatusCodes.Status200OK);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }


        // DELETE api/<CartingController>/delete/1/2
        [HttpDelete("v1/DeleteItem/{cartId}/{itemId}")]
        public async Task<IActionResult> DeleteItem(string cartId, int itemId)
        {
            if (itemId <= 0)
            {
                return BadRequest("Invalid Item Id");
            }
            try
            {
                await cartingRepository.DeleteItem(cartId, itemId);
                return StatusCode(StatusCodes.Status200OK);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("v2/GetCartInfo/{cartId}")]
        public async Task<IActionResult> GetCartInfoV2(string cartId)
        {
            if (string.IsNullOrEmpty(cartId))
            {
                return BadRequest("Invalid cart Id");
            }

            try
            {
                var result = await cartingRepository.GetCartInfo(cartId);
                return StatusCode(StatusCodes.Status200OK, result.CartItems);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);

            }
        }


        // POST api/<CartingController>
        [HttpPost]
        [Route("v2/AddItem")]
        public async Task<IActionResult> AddItemV2([FromBody] Cart cart)
        {
            try
            {
                await cartingRepository.AddItem(cart);
                return StatusCode(StatusCodes.Status200OK);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }


        // DELETE api/<CartingController>/delete/1/2
        [HttpDelete("v2/DeleteItem/{cartId}/{itemId}")]
        public async Task<IActionResult> DeleteItemV2(string cartId, int itemId)
        {
            if (itemId <= 0)
            {
                return BadRequest("Invalid Item Id");
            }
            try
            {
                await cartingRepository.DeleteItem(cartId, itemId);
                return StatusCode(StatusCodes.Status200OK);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
