using Azure.Core;
using CodeBridge.BLL.Interfaces;
using CodeBridge.Models;
using Microsoft.AspNetCore.Mvc;

namespace CodeBridge.Controllers
{
    [ApiController]
    public class DogAPI : ControllerBase
    {
        private readonly IDogService _dogService;

        public DogAPI(IDogService dogService)
        {
            _dogService = dogService;
        }

        [HttpGet("ping")]
        public async Task<IActionResult> Ping()
        {
            return StatusCode(StatusCodes.Status200OK, await _dogService.PingAsync());
        }

        [HttpGet("dogs")]
        public async Task<IActionResult> GetDogs([FromQuery] string? attribute = "name", [FromQuery] string? order = "desc",
                                                 [FromQuery] int pageNumber = 1, [FromQuery] int limit = 10)
        {
            return StatusCode(StatusCodes.Status200OK, await _dogService.GetDogsAsync(attribute, order, pageNumber, limit));
        }

        [HttpPost("dog")]
        public async Task<IActionResult> PostDog(Dog dogRequest)
        {
            var isItemCreated = await _dogService.PostDog(dogRequest);

            return StatusCode(isItemCreated ? StatusCodes.Status200OK : StatusCodes.Status409Conflict, isItemCreated);
        }
    }
}
