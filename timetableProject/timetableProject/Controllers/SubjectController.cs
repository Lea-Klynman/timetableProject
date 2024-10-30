using Microsoft.AspNetCore.Mvc;
using timetableProject.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace timetableProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectController : ControllerBase
    {
        readonly SubjectService _subject=new SubjectService();
        // GET: api/<SubjectController>
        [HttpGet]
        public ActionResult<List<Subject>> Get()
        {
           List<Subject> result = _subject.GetList();
            if (result == null) {return Unauthorized();}
            return Ok(result);
        }

        // GET api/<SubjectController>/5
        [HttpGet("{id}")]
        public ActionResult<Subject> Get(int id)
        {
            Subject  result = _subject.GetSubjectId(id);
            if (result == null) { return Unauthorized(); }
            return Ok(result);
        }

        // POST api/<SubjectController>
        [HttpPost]
        public ActionResult<bool> Post([FromBody] Subject value)
        {
            bool flag= _subject.AddItem(value);
            return flag == true ? Ok(true) : NotFound(false);
        }

        // PUT api/<SubjectController>/5
        [HttpPut("{id}")]
        public ActionResult<bool> Put(int id, [FromBody] Subject value)
        {
            bool flag= _subject.Update(id, value);
            return flag == true ? Ok(true) : NotFound(false);
        }

        // DELETE api/<SubjectController>/5
        [HttpDelete("{id}")]
        public ActionResult<bool> Delete(int id)
        {
            bool flag= _subject.RemoveItem(id);
            return flag == true ? Ok(true) : NotFound(false);
        }
    }
}
