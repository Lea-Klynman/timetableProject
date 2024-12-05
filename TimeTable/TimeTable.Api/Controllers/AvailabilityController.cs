using Microsoft.AspNetCore.Mvc;
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
        public AvailabilityController(IAvailabilityService availabilityService)
        {
            _availabilityService = availabilityService;
        }
        // GET: api/<AvailabilityController>
        [HttpGet]
        public ActionResult<IEnumerable<AvailabilityEntity>> Get()
        {
            return Ok(_availabilityService.GetList());
        }

        // GET api/<AvailabilityController>/5
        [HttpGet("{id}")]
        public ActionResult<AvailabilityEntity> GetById(int id)
        {
            if (id < 0) return BadRequest();
            return _availabilityService.GetById(id);
        }

        // POST api/<AvailabilityController>
        [HttpPost]
        public ActionResult<bool> Post([FromBody] AvailabilityEntity value)
        {
            if (value == null || !_availabilityService.AddItem(value)) return BadRequest();
            return true;
        }

        // PUT api/<AvailabilityController>/5
        [HttpPut("{id}")]
        public ActionResult<bool> Put(int id, [FromBody] AvailabilityEntity value)
        {
            if (id < 0 || value == null) return BadRequest();
            if (!_availabilityService.Update(id, value)) return NotFound();
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
