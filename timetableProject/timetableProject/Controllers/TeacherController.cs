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
            List<Teacher> result=_teacher.GetList();
            if (result == null)return Unauthorized();
            return Ok(result);
        }

        // GET api/<TeacherController>/5
        [HttpGet("{id}")]
        public ActionResult<Teacher> Get(int id)
        {
            Teacher result = _teacher.GetTeacherId(id);
            if (result == null) return Unauthorized();
            return Ok(result);
        }

        // POST api/<TeacherController>
        [HttpPost]
        public ActionResult<bool> Post([FromBody] Teacher value)
        {
            bool flag= _teacher.AddItem(value);
            return flag == true ? Ok(true) : NotFound(false);
        }

        // PUT api/<TeacherController>/5
        [HttpPut("{id}")]
        public ActionResult<bool> Put(int id, [FromBody] Teacher value)
        {
            bool flag= _teacher.Update(id, value);
            return flag == true ? Ok(true) : NotFound(false);
        }

        // DELETE api/<TeacherController>/5
        [HttpDelete("{id}")]
        public ActionResult<bool> Delete(int id)
        {
            bool flag= _teacher.RemoveItem(id);
            return flag == true ? Ok(true) : NotFound(false);
        }
    }
}
