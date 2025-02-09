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
    public class SubjectController : ControllerBase
    {
        readonly ISubjectService _subjectService;
        private readonly IMapper _mapper;
        public SubjectController(ISubjectService subjectService,IMapper mapper)
        {
            _subjectService = subjectService;
            _mapper = mapper;
        }

        // GET: api/<SubjectController>
        [HttpGet]
        public ActionResult< IEnumerable<SubjectDto>> Get()
        {
            return Ok(_subjectService.GetList());
        }

        // GET api/<SubjectController>/5
        [HttpGet("{id}")]
        public ActionResult< SubjectDto>GetById(int id)
        {
            if(id < 0) { return BadRequest(); }
            return _mapper.Map<SubjectDto>(_subjectService.GetById(id));
        }

        // POST api/<SubjectController>
        [HttpPost]
        public ActionResult<SubjectDto> Post([FromBody] SubjectPostModel value)
        {
            if(value == null || !_subjectService.AddItem(_mapper.Map<SubjectEntity>(value))) { return BadRequest(); }
            return _mapper.Map <SubjectDto>(value);
        }

        // PUT api/<SubjectController>/5
        [HttpPut("{id}")]
        public ActionResult<bool> Put(int id, [FromBody] SubjectPostModel value)
        {
            if(id < 0 || value==null) {return BadRequest(); }
            if(!_subjectService.Update(id, _mapper.Map<SubjectEntity>(value))) { return NotFound(); };
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
