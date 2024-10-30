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
            return Ok(result);
        }

        // GET api/<AvailabilityController>/5
        [HttpGet("{id}")]
        public ActionResult<Availability> Get(int id)
        {
            Availability result=_availability.GetAvailabilityId(id);
            if (result == null) return Unauthorized();
            return Ok(result);
        }

        // POST api/<AvailabilityController>
        [HttpPost]
        public ActionResult<bool> Post([FromBody] Availability value)
        {bool flag= _availability.AddItem(value);
            return flag==true?Ok(true):NotFound( false);
        }

        // PUT api/<AvailabilityController>/5
        [HttpPut("{id}")]
        public ActionResult<bool> Put(int id, [FromBody] Availability value)
        {
            bool flag= _availability.Update(id, value);
            return flag == true ? Ok(true) : NotFound(false);

        }

        // DELETE api/<AvailabilityController>/5
        [HttpDelete("{id}")]
        public ActionResult<bool> Delete(int id)
        {
            bool flag= _availability.RemoveItem(id);
            return flag == true ? Ok(true) : NotFound(false);

        }
    }
}
