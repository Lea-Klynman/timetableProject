using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TimeTable.Api.PostModels;
using TimeTable.Core.Dtos;
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
        private readonly IMapper _mapper;
        public TeacherController(ITeacherService teacherService,IMapper mapper)
        {
            _teacherService = teacherService;
            _mapper = mapper;
        }
        // GET: api/<TeacherController>
        [HttpGet]
        public ActionResult<IEnumerable<TeacherDto>> Get()
        {
            return Ok(_teacherService.GetList());
        }

        // GET api/<TeacherController>/5
        [HttpGet("{id}")]
        public ActionResult<TeacherDto> GetById(int id)
        {
            if (id < 0) { return BadRequest(); }
            var item = _teacherService.GetById(id);
            if (item == null) { return NotFound(); }
            return _mapper.Map<TeacherDto>( item);
        }

        // POST api/<TeacherController>
        [HttpPost]
        public ActionResult<TeacherDto> Post([FromBody] TeacherPostModel value)
        {
            if (value == null )
            {
                return BadRequest();
            }
            var res = _teacherService.AddItem(_mapper.Map<TeacherDto>(value));
            if(res==null) return NotFound();
            return res;
        }

        // PUT api/<TeacherController>/5
        [HttpPut("{id}")]
        public ActionResult<bool> Put(int id, [FromBody] TeacherPostModel value)
        {
            if (id < 0 || value == null) { return BadRequest(); }
            if (!_teacherService.Update(id,_mapper.Map<TeacherDto>( value))) return NotFound();
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
