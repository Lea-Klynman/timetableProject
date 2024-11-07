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
            return _teacherClassSubject.GetList();
        }

        // GET api/<TeacherClassSubjectController>/5
        [HttpGet("{id}")]
        public ActionResult<TeacherClassSubject> Get(int id)
        {
            if (id < 0) return BadRequest();
            TeacherClassSubject  result = _teacherClassSubject.GetTeacherClassSubjectId(id);
            if (result == null) { return NotFound(); }
            return result;
        }

        // POST api/<TeacherClassSubjectController>
        [HttpPost]
        public ActionResult<bool> Post([FromBody] TeacherClassSubject value)
        { if(value == null||value.ClassId<0||value.TeacherId<0||value.SubjectId<0)
                return BadRequest();
            return _teacherClassSubject.AddItem(value);
        }

        // PUT api/<TeacherClassSubjectController>/5
        [HttpPut("{id}")]
        public ActionResult<bool> Put(int id, [FromBody] TeacherClassSubject value)
        {
            if (id < 0 || value == null || value.ClassId < 0 || value.TeacherId < 0 || value.SubjectId < 0)
                return BadRequest();
            bool flag = _teacherClassSubject.Update(id, value);
            return flag == true ? true : NotFound(false);
        }

        // DELETE api/<TeacherClassSubjectController>/5
        [HttpDelete("{id}")]
        public ActionResult<bool> Delete(int id)
        {
            if(id < 0) { return BadRequest(); }
            bool flag= _teacherClassSubject.RemoveItem(id);
            return flag == true ? true : NotFound(false);
        }
    }
}
