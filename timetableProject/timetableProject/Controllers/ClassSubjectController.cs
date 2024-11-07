using Microsoft.AspNetCore.Mvc;
using timetableProject.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace timetableProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassSubjectController : ControllerBase
    {
        readonly ClassSubjectService _classSubject = new ClassSubjectService();
        // GET: api/<ClassSubjectController>
        [HttpGet]
        public ActionResult<List<ClassSubject>> Get()
        {
            return _classSubject.GetList();
           
        }

        // GET api/<ClassSubjectController>/5
        [HttpGet("{id}")]
        public ActionResult<ClassSubject> Get(int id)
        {
            if (id < 0) { return BadRequest(); }
            ClassSubject result = _classSubject.GetClassSubjectId(id);
            if (result == null) { return NotFound(); }
            return result;
        }

        // POST api/<ClassSubjectController>
        [HttpPost]
        public ActionResult<bool> Post([FromBody] ClassSubject value)
        {
            if(value == null) { return BadRequest(); }
            return _classSubject.AddItem(value);
        }

        // PUT api/<ClassSubjectController>/5
        [HttpPut("{id}")]
        public ActionResult<bool> Put(int id, [FromBody] ClassSubject value)
        {
            if(id < 0||value==null) {return BadRequest(); }
            bool flag= _classSubject.Update(id, value);
            return flag == true ? true : NotFound(false);

        }

        // DELETE api/<ClassSubjectController>/5
        [HttpDelete("{id}")]
        public ActionResult<bool> Delete(int id)
        {
            if(id < 0) {return BadRequest(); }
            bool flag= _classSubject.RemoveItem(id);
            return flag == true ? Ok(true) : NotFound(false);
        }
    }
}
