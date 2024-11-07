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
            return _availability.GetList();
            
        }

        // GET api/<AvailabilityController>/5
        [HttpGet("{id}")]
        public ActionResult<Availability> Get(int id)
        {
            if (id < 0 )
                return BadRequest();
            Availability result=_availability.GetAvailabilityId(id);
            if (result == null) return NotFound();
            return result;
        }

        // POST api/<AvailabilityController>
        [HttpPost]
        public ActionResult<bool> Post([FromBody] Availability value)
        {
            if (value == null) return BadRequest();
            return _availability.AddItem(value);
        }

        // PUT api/<AvailabilityController>/5
        [HttpPut("{id}")]
        public ActionResult<bool> Put(int id, [FromBody] Availability value)
        {
            if (id < 0 ||value==null)return BadRequest();
            bool flag= _availability.Update(id, value);
            return flag == true ? flag : NotFound(false);

        }

        // DELETE api/<AvailabilityController>/5
        [HttpDelete("{id}")]
        public ActionResult<bool> Delete(int id)
        {
            if(id < 0 ) return BadRequest();
            bool flag= _availability.RemoveItem(id);
            return flag == true ? flag : NotFound(false);

        }
    }
}
