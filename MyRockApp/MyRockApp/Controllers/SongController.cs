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
    public class SongController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ISongService _service;

        public SongController(IMapper mapper, ISongService service)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }

        [HttpGet(Name = "GetAllSongs")]
        public IActionResult GetAllSongs()
        {
            var artists = _service.GetAll();
            return Ok(_mapper.Map<List<Artist>>(artists));
        }
    }
}