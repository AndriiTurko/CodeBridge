using CodeBridge.BLL.Interfaces;
using CodeBridge.Models;
using Microsoft.AspNetCore.Mvc;

namespace CodeBridge.Controllers
{
    [ApiController]
    public class DogController : ControllerBase
    {
        private readonly IDogService _dogService;
        private readonly ILogger<DogController> _logger;

        public DogController(IDogService dogService, ILogger<DogController> logger)
        {
            _dogService = dogService;
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpGet("ping")]
        public async Task<IActionResult> Ping()
        {
            return Ok(await _dogService.PingAsync());
        }

        [HttpGet("dogs")]
        public async Task<IActionResult> GetDogs([FromQuery] string? attribute = "name", [FromQuery] string? order = "desc",
                                                 [FromQuery] int pageNumber = 1, [FromQuery] int limit = 10)
        {
            return Ok(await _dogService.GetDogsAsync(attribute, order, pageNumber, limit));
        }

        [HttpPost("dog")]
        public async Task<IActionResult> PostDog(DogForCreationDTO dogForCreationDTO)
        {
            var isItemCreated = await _dogService.PostDog(dogForCreationDTO);

            return StatusCode(isItemCreated ? StatusCodes.Status201Created : StatusCodes.Status409Conflict, isItemCreated);
        }
    }
}
