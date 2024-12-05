using Microsoft.AspNetCore.Mvc;
using TimeTable.Core.Entity;
using TimeTable.Core.IService;



// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TimeTable.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        readonly ITeacherService _teacherService;
        public TeacherController(ITeacherService teacherService)
        {
            _teacherService = teacherService;
        }
        // GET: api/<TeacherController>
        [HttpGet]
        public ActionResult<IEnumerable<TeacherEntity>> Get()
        {
            return Ok(_teacherService.GetList());
        }

        // GET api/<TeacherController>/5
        [HttpGet("{id}")]
        public ActionResult<TeacherEntity> GetById(int id)
        {
            if (id < 0) { return BadRequest(); }
            var item = _teacherService.GetById(id);
            if (item == null) { return NotFound(); }
            return item;
        }

        // POST api/<TeacherController>
        [HttpPost]
        public ActionResult<bool> Post([FromBody] TeacherEntity value)
        {
            if (value == null || !_teacherService.AddItem(value))
            {
                return BadRequest();
            }
            return true;
        }

        // PUT api/<TeacherController>/5
        [HttpPut("{id}")]
        public ActionResult<bool> Put(int id, [FromBody] TeacherEntity value)
        {
            if (id < 0 || value == null) { return BadRequest(); }
            if (!_teacherService.Update(id, value)) return NotFound();
            return true;
        }

        // DELETE api/<TeacherController>/5
        [HttpDelete("{id}")]
        public ActionResult<bool> Delete(int id)
        {
            if (id < 0) { return BadRequest(); }
            if (!_teacherService.RemoveItem(id)) { return NotFound(); }
            return true;
        }
    }
}
