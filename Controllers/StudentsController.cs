using api_with_MongoDb.Models;
using api_with_MongoDb.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace api_with_MongoDb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentService studentService;

        public StudentsController(IStudentService studentService)
        {
            this.studentService = studentService;
        }

        // GET: api/<StudentsController>
        [HttpGet]
        public ActionResult< List<Student>> Get()
        {
            return studentService.Get();
        }

        // GET api/<StudentsController>/5
        [HttpGet("{id}")]
        public ActionResult<Student> Get(string id)
        {
            var student = studentService.GetById(id);
            if (student==null)
            {
                return NotFound($"Student with id = {id} not found");
            }
            return student;
        }

        // POST api/<StudentsController>
        [HttpPost]
        public ActionResult<Student> Post([FromBody] Student student)
        {
            studentService.Create(student);
            return CreatedAtAction(nameof(Get), new { id = student.Id }, student);
        }

        // PUT api/<StudentsController>/5
        [HttpPut("{id}")]
        public ActionResult Put(string id, [FromBody] Student student)
        {
            var existingStudent = studentService.GetById(id);
            if (existingStudent == null)
            {
                return NotFound($"Student with id = {id} not found");
            }
            studentService.Update(id, student);
            return NoContent();


        }

        // DELETE api/<StudentsController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            var existingStudent = studentService.GetById(id);
            if (existingStudent == null)
            {
                return NotFound($"Student with id = {id} not found");
            }
            studentService.Delete(id);
            return Ok($"Student with id = {id} deleted");
        }
    }
}
