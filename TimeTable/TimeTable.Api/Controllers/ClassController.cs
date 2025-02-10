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
    public class ClassController : ControllerBase
    {
        readonly IClassService _classService;
        private readonly IMapper _mapper;
        public ClassController(IClassService classService,IMapper mapper)
        {
            _classService = classService;
            _mapper = mapper;
        }
        // GET: api/<ClassController>
        [HttpGet]
        public ActionResult<IEnumerable<ClassDto>> Get()
        {
            return Ok(_classService.GetList());
        }

        // GET api/<ClassController>/5
        [HttpGet("{id}")]
        public ActionResult<ClassDto> GetById(int id)
        {
            if (id < 0) { return BadRequest(); }
            var res=_mapper.Map<ClassDto>(_classService.GetById(id));
            if(res == null) { return NotFound(); }
            return Ok(res);
        }

        // POST api/<ClassController>
        [HttpPost]
        public ActionResult<ClassDto> Post([FromBody] ClassPostModel value)
        {
            if (value == null ) { return BadRequest(); }
            var res = _classService.AddItem(_mapper.Map<ClassDto>(value));
            if (res == null)
            {
               return BadRequest();
            }
            return res;
        }

        // PUT api/<ClassController>/5
        [HttpPut("{id}")]
        public ActionResult<bool> Put(int id, [FromBody] ClassPostModel value)
        {
            if(id < 0 || value==null ) {return BadRequest(); }
            if(!_classService.Update(id, _mapper.Map<ClassDto>(value))) return NotFound();
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
