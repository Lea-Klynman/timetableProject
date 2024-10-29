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
            return result;
        }

        // GET api/<ClassController>/5
        [HttpGet("{id}")]
        public ActionResult<Class> Get(int id)
        {
            Class result = _class.GetClassId(id);
            if (result == null) { return Unauthorized(); }
            return result;
        }

        // POST api/<ClassController>
        [HttpPost]
        public ActionResult<bool> Post([FromBody] Class value)
        {
            return _class.AddItem(value);
        }

        // PUT api/<ClassController>/5
        [HttpPut("{id}")]
        public ActionResult<bool> Put(int id, [FromBody] Class value)
        {
            return _class.Update(id, value);
        }

        // DELETE api/<ClassController>/5
        [HttpDelete("{id}")]
        public ActionResult<bool> Delete(int id)
        {
            return _class.RemoveItem(id);
        }
    }
}
