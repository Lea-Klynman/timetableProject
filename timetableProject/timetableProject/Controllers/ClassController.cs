using Microsoft.AspNetCore.Mvc;
using timetableProject.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace timetableProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassController : ControllerBase
    {
        readonly ClassService _class= new ClassService();
        // GET: api/<ClassController>
        [HttpGet]
        public ActionResult<List<Class>> Get()
        {
            List<Class> result=_class.GetList();
            if (result == null) {return Unauthorized();}
            return Ok(result);
        }

        // GET api/<ClassController>/5
        [HttpGet("{id}")]
        public ActionResult<Class> Get(int id)
        {
            Class result = _class.GetClassId(id);
            if (result == null) { return Unauthorized(); }
            return Ok(result);
        }

        // POST api/<ClassController>
        [HttpPost]
        public ActionResult<bool> Post([FromBody] Class value)
        {
            bool flag= _class.AddItem(value);
            return flag == true ? Ok(true) : NotFound(false);

        }

        // PUT api/<ClassController>/5
        [HttpPut("{id}")]
        public ActionResult<bool> Put(int id, [FromBody] Class value)
        {
            bool flag = _class.Update(id, value);
            return flag == true ? Ok(true) : NotFound(false);

        }

        // DELETE api/<ClassController>/5
        [HttpDelete("{id}")]
        public ActionResult<bool> Delete(int id)
        {
            bool flag= _class.RemoveItem(id);
            return flag == true ? Ok(true) : NotFound(false);
        }
    }
}
