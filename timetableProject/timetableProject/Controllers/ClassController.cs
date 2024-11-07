using Microsoft.AspNetCore.Mvc;
using timetableProject.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace timetableProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassController : ControllerBase
    {
        readonly ClassService _class= new ClassService();
        // GET: api/<ClassController>
        [HttpGet]
        public ActionResult<List<Class>> Get()
        {
            return _class.GetList();
        }

        // GET api/<ClassController>/5
        [HttpGet("{id}")]
        public ActionResult<Class> Get(int id)
        {if (id < 0) { return BadRequest(); }
            Class result = _class.GetClassId(id);
            if (result == null) { return NotFound(); }
            return result;
        }

        // POST api/<ClassController>
        [HttpPost]
        public ActionResult<bool> Post([FromBody] Class value)
        {
            if(value == null) { return BadRequest(); }
            return _class.AddItem(value);
        }

        // PUT api/<ClassController>/5
        [HttpPut("{id}")]
        public ActionResult<bool> Put(int id, [FromBody] Class value)
        {
            if (id < 0||value==null) {return BadRequest(); }
            bool flag = _class.Update(id, value);
            return flag == true ? flag : NotFound(false);

        }

        // DELETE api/<ClassController>/5
        [HttpDelete("{id}")]
        public ActionResult<bool> Delete(int id)
        {if(id < 0) {return BadRequest(); }
            bool flag= _class.RemoveItem(id);
            return flag == true ? flag : NotFound(false);
        }
    }
}
