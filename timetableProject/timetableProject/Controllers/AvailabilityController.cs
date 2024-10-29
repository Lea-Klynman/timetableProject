using Microsoft.AspNetCore.Mvc;
using timetableProject.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace timetableProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AvailabilityController : ControllerBase
    {
        readonly AvailabilityService _availability=new AvailabilityService();
        // GET: api/<AvailabilityController>
        [HttpGet]
        public ActionResult<List<Availability>> Get()
        {
            List<Availability> result=_availability.GetList();
            if (result == null) { return Unauthorized(); }
            return result;
        }

        // GET api/<AvailabilityController>/5
        [HttpGet("{id}")]
        public ActionResult<Availability> Get(int id)
        {
            Availability result=_availability.GetAvailabilityId(id);
            if (result == null) return Unauthorized();
            return result;
        }

        // POST api/<AvailabilityController>
        [HttpPost]
        public ActionResult<bool> Post([FromBody] Availability value)
        {
            return _availability.AddItem(value);
        }

        // PUT api/<AvailabilityController>/5
        [HttpPut("{id}")]
        public ActionResult<bool> Put(int id, [FromBody] Availability value)
        {
            return _availability.Update(id, value);
        }

        // DELETE api/<AvailabilityController>/5
        [HttpDelete("{id}")]
        public ActionResult<bool> Delete(int id)
        {
            return _availability.RemoveItem(id);
        }
    }
}
