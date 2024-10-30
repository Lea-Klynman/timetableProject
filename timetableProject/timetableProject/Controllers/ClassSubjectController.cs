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
            List<ClassSubject> result=_classSubject.GetList();
            if(result == null) {return Unauthorized();}
            return Ok(result);
        }

        // GET api/<ClassSubjectController>/5
        [HttpGet("{id}")]
        public ActionResult<ClassSubject> Get(int id)
        {
            ClassSubject result = _classSubject.GetClassSubjectId(id);
            if (result == null) { return Unauthorized(); }
            return Ok(result);
        }

        // POST api/<ClassSubjectController>
        [HttpPost]
        public ActionResult<bool> Post([FromBody] ClassSubject value)
        {
            bool flag= _classSubject.AddItem(value);
            return flag == true ? Ok(true) : NotFound(false);

        }

        // PUT api/<ClassSubjectController>/5
        [HttpPut("{id}")]
        public ActionResult<bool> Put(int id, [FromBody] ClassSubject value)
        {
            bool flag= _classSubject.Update(id, value);
            return flag == true ? Ok(true) : NotFound(false);

        }

        // DELETE api/<ClassSubjectController>/5
        [HttpDelete("{id}")]
        public ActionResult<bool> Delete(int id)
        {
            bool flag= _classSubject.RemoveItem(id);
            return flag == true ? Ok(true) : NotFound(false);
        }
    }
}
