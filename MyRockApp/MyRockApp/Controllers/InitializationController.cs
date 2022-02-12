using Microsoft.AspNetCore.Mvc;
using MyRockApp.Services;

namespace MyRockApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InitializationController : ControllerBase
    {
        private readonly IInitializationService _service;

        public InitializationController(IInitializationService service)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }

        [HttpPut(Name = "Initialize")]
        public IActionResult Initialize()
        {
            _service.Initialize();
            return Ok();
        }
    }
}
