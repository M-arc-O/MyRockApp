using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MyRockApp.Attributes;
using MyRockApp.Models;
using MyRockApp.Services;

namespace MyRockApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [ApiKeyAttribute]
    public class ArtistController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IArtistService _service;

        public ArtistController(IMapper mapper, IArtistService service)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }

        [HttpGet(Name = "GetAllArtists")]
        public IActionResult GetAllArtists()
        {
            var artists = _service.GetAll();
            return Ok(_mapper.Map<List<Artist>>(artists));
        }
    }
}