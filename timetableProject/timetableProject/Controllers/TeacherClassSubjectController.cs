using Microsoft.AspNetCore.Mvc;
using timetableProject.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace timetableProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherClassSubjectController : ControllerBase
    {
        readonly TeacherClassSubjectService _teacherClassSubject= new TeacherClassSubjectService();
        // GET: api/<TeacherClassSubjectController>
        [HttpGet]
        public ActionResult<List<TeacherClassSubject>> Get()
        {
            List<TeacherClassSubject>result=_teacherClassSubject.GetList();
            if (result == null) {return Unauthorized();}
            return Ok(result);
        }

        // GET api/<TeacherClassSubjectController>/5
        [HttpGet("{id}")]
        public ActionResult<TeacherClassSubject> Get(int id)
        {
            TeacherClassSubject  result = _teacherClassSubject.GetTeacherClassSubjectId(id);
            if (result == null) { return Unauthorized(); }
            return Ok(result);
        }

        // POST api/<TeacherClassSubjectController>
        [HttpPost]
        public ActionResult<bool> Post([FromBody] TeacherClassSubject value)
        {
            bool flag= _teacherClassSubject.AddItem(value);
            return flag == true ? Ok(true) : NotFound(false);
        }

        // PUT api/<TeacherClassSubjectController>/5
        [HttpPut("{id}")]
        public ActionResult<bool> Put(int id, [FromBody] TeacherClassSubject value)
        {
            bool flag= _teacherClassSubject.Update(id, value);
            return flag == true ? Ok(true) : NotFound(false);
        }

        // DELETE api/<TeacherClassSubjectController>/5
        [HttpDelete("{id}")]
        public ActionResult<bool> Delete(int id)
        {
            bool flag= _teacherClassSubject.RemoveItem(id);
            return flag == true ? Ok(true) : NotFound(false);
        }
    }
}
