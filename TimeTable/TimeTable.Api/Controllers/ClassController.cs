using Microsoft.AspNetCore.Mvc;
using TimeTable.Core.Entity;
using TimeTable.Core.IService;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TimeTable.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassController : ControllerBase
    {
        readonly IGenericService<ClassEntity> _classService;
        public ClassController(IGenericService<ClassEntity> classService)
        {
            _classService = classService;
        }
        // GET: api/<ClassController>
        [HttpGet]
        public ActionResult<IEnumerable<ClassEntity>> Get()
        {
            return Ok(_classService.GetList());
        }

        // GET api/<ClassController>/5
        [HttpGet("{id}")]
        public ActionResult<ClassEntity> GetById(int id)
        {
            if (id < 0) { return BadRequest(); }
            return _classService.GetById(id);
        }

        // POST api/<ClassController>
        [HttpPost]
        public ActionResult<bool> Post([FromBody] ClassEntity value)
        {
            if (value == null || !_classService.AddItem(value)) { return BadRequest(); }
            return true;
        }

        // PUT api/<ClassController>/5
        [HttpPut("{id}")]
        public ActionResult<bool> Put(int id, [FromBody] ClassEntity value)
        {
            if(id < 0 || value==null ) {return BadRequest(); }
            if(!_classService.Update(id,value)) return NotFound();
            return true;
        }

        // DELETE api/<ClassController>/5
        [HttpDelete("{id}")]
        public ActionResult<bool> Delete(int id)
        {
            if (id < 0) {return BadRequest(); }
            if(!_classService.RemoveItem(id)) return NotFound();
            return true;
        }
    }
}
