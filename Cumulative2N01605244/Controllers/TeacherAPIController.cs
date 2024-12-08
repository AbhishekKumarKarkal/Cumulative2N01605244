using Cumulative2N01605244.Models;
using Microsoft.AspNetCore.Mvc;

namespace Cumulative2N01605244.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherAPIController : ControllerBase
    {
        private readonly SchoolDbContext _context;

        public TeacherAPIController(SchoolDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult AddTeacher([FromBody] Teacher teacher)
        {
            if (string.IsNullOrEmpty(teacher.Name))
                return BadRequest("Teacher name is required.");

            _context.Teachers.Add(teacher);
            _context.SaveChanges();
            return Ok(teacher);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTeacher(int id)
        {
            var teacher = _context.Teachers.Find(id);
            if (teacher == null)
                return NotFound("Teacher not found.");

            _context.Teachers.Remove(teacher);
            _context.SaveChanges();
            return Ok($"Teacher {teacher.Name} deleted.");
        }
    }
}

