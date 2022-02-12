using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MyRockApp.Attributes;
using MyRockApp.Models;
using MyRockApp.Services;
using MyRockApp.Services.Exceptions;

namespace MyRockApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [ApiKey]
    public class ArtistController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IArtistService _service;

        public ArtistController(IMapper mapper, IArtistService service)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }

        [HttpGet]
        public IActionResult GetAllArtists()
        {
            var artists = _service.GetAll();
            return Ok(_mapper.Map<List<Artist>>(artists));
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetById(int id)
        {
            var artist = _service.GetById(id);
            return Ok(_mapper.Map<Artist>(artist));
        }

        [HttpGet]
        [Route("getbyname")]
        public IActionResult GetByName(string name)
        {
            var artists = _service.GetByName(name);
            return Ok(_mapper.Map<Artist>(artists));
        }

        [HttpPost]
        public IActionResult Add(Artist artist)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            try
            {
                _service.Add(_mapper.Map<Data.Models.Artist>(artist));
                return Ok();
            }
            catch (DuplicateException)
            {
                return BadRequest("Artist already exists");
            }
            catch 
            { 
                return StatusCode(500);
            }
        }

        [HttpPut]
        public IActionResult Edit(Artist artist)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            try
            {
                _service.Update(_mapper.Map<Data.Models.Artist>(artist));
                return Ok();
            }
            catch (DuplicateException)
            {
                return BadRequest("Artist already exists");
            }
            catch (NotFoundException)
            {
                return NotFound("Artist not found");
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _service.Delete(id);
                return Ok();
            }
            catch (NotFoundException)
            {
                return NotFound("Artist not found");
            }
            catch
            {
                return StatusCode(500);
            }
        }
    }
}