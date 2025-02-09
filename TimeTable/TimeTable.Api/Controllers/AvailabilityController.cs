using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TimeTable.Api.PostModels;
using TimeTable.Core.Dtos;
using TimeTable.Core.Entity;
using TimeTable.Core.IService;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TimeTable.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AvailabilityController : ControllerBase
    {
        readonly IAvailabilityService _availabilityService;
        private readonly IMapper _mapper;
        public AvailabilityController(IAvailabilityService availabilityService,IMapper mapper)
        {
            _availabilityService = availabilityService;
            _mapper = mapper;
        }
        // GET: api/<AvailabilityController>
        [HttpGet]
        public ActionResult<IEnumerable<AvailabilityDto>> Get()
        {
            return Ok(_availabilityService.GetList());
        }

        // GET api/<AvailabilityController>/5
        [HttpGet("{id}")]
        public ActionResult<AvailabilityDto> GetById(int id)
        {
            if (id < 0) return BadRequest();
            return _mapper.Map<AvailabilityDto>(_availabilityService.GetById(id));
        }

        // POST api/<AvailabilityController>
        [HttpPost]
        public ActionResult<AvailabilityDto> Post([FromBody] AvailabilityPostModel value)
        {
            if (value == null || !_availabilityService.AddItem(_mapper.Map<AvailabilityEntity>(value))) return BadRequest();
            return _mapper.Map<AvailabilityDto>(value);
        }

        // PUT api/<AvailabilityController>/5
        [HttpPut("{id}")]
        public ActionResult<bool> Put(int id, [FromBody] AvailabilityPostModel value)
        {
            if (id < 0 || value == null) return BadRequest();
            if (!_availabilityService.Update(id, _mapper.Map<AvailabilityEntity>(value))) return NotFound();
            return true;
        }

        // DELETE api/<AvailabilityController>/5
        [HttpDelete("{id}")]
        public ActionResult<bool> Delete(int id)
        {
            if (id < 0) return BadRequest();
            if (!_availabilityService.RemoveItem(id)) return NotFound();
            return true;
        }
    }
}
