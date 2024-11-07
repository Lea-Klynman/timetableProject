using Microsoft.AspNetCore.Mvc;
using timetableProject.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace timetableProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        readonly TeacherService _teacher= new TeacherService();
        // GET: api/<TeacherController>
        [HttpGet]
        public ActionResult<List<Teacher>> Get()
        {
            return _teacher.GetList();
            
        }

        // GET api/<TeacherController>/5
        [HttpGet("{id}")]
        public ActionResult<Teacher> Get(int id)
        {   if (id< 0)
                return BadRequest();
            Teacher result = _teacher.GetTeacherId(id);
            if (result == null) return NotFound();
            return result;
        }

        // POST api/<TeacherController>
        [HttpPost]
        public ActionResult<bool> Post([FromBody] Teacher value)
        {
            if(value==null||!Validation.IdString(value.Id))
                return BadRequest();
            return _teacher.AddItem(value);
        }

        // PUT api/<TeacherController>/5
        [HttpPut("{id}")]
        public ActionResult<bool> Put(int id, [FromBody] Teacher value)
        {
            if (value == null ||id<0|| !Validation.IdString(value.Id))
                return BadRequest();
            return _teacher.Update(id, value);
        }

        // DELETE api/<TeacherController>/5
        [HttpDelete("{id}")]
        public ActionResult<bool> Delete(int id)
        {
            if(id<0)
                return BadRequest();
            return _teacher.RemoveItem(id);
        }
    }
}
