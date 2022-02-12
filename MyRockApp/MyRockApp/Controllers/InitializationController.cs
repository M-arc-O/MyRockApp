using Microsoft.AspNetCore.Mvc;
using MyRockApp.Attributes;
using MyRockApp.Services;

namespace MyRockApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [ApiKey]
    public class InitializationController : ControllerBase
    {
        private readonly IInitializationService _service;

        public InitializationController(IInitializationService service)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }

        [HttpPut(Name = "Initialize")]
        public async Task<IActionResult> Initialize()
        {
            await _service.InitializeAsync();
            return Ok();
        }
    }
}
