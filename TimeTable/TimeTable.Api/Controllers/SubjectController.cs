using Microsoft.AspNetCore.Mvc;
using TimeTable.Core.Entity;
using TimeTable.Core.IService;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TimeTable.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectController : ControllerBase
    {
        readonly ISubjectService _subjectService;
        public SubjectController(ISubjectService subjectService)
        {
            _subjectService = subjectService; 
        }

        // GET: api/<SubjectController>
        [HttpGet]
        public ActionResult< IEnumerable<SubjectEntity>> Get()
        {
            return Ok(_subjectService.GetList());
        }

        // GET api/<SubjectController>/5
        [HttpGet("{id}")]
        public ActionResult< SubjectEntity>GetById(int id)
        {
            if(id < 0) { return BadRequest(); }
            return _subjectService.GetById(id);
        }

        // POST api/<SubjectController>
        [HttpPost]
        public ActionResult<bool> Post([FromBody] SubjectEntity value)
        {
            if(value == null || !_subjectService.AddItem(value)) { return BadRequest(); }
            return true;
        }

        // PUT api/<SubjectController>/5
        [HttpPut("{id}")]
        public ActionResult<bool> Put(int id, [FromBody] SubjectEntity value)
        {
            if(id < 0 || value==null) {return BadRequest(); }
            if(!_subjectService.Update(id, value)) { return NotFound(); };
            return true;
        }

        // DELETE api/<SubjectController>/5
        [HttpDelete("{id}")]
        public ActionResult<bool> Delete(int id)
        {
            if(id<0 ) { return BadRequest(); }
            if(! _subjectService.RemoveItem(id))
                { return NotFound(); }
            return true;
        }
    }
}
