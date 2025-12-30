using ADOwebAPI.Models;
using ADOwebAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace ADOwebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController:ControllerBase
    {
        private readonly IStudentService std;

        public StudentController(IStudentService _std)
        {
            std = _std;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<Students> stds = std.GetStudents();
            if (stds == null) return NotFound();
            return Ok(stds);
        }

        [HttpPost]
        public IActionResult AddStudents(Students student)
        {
            std.Posting(student);
            return Ok("Student added succesfully");
        }
        [HttpPut]
        public IActionResult UpdateStd(Students student)
        {
            std.Update(student);
            return Ok("Update Student succcessfully");
        }
        [HttpDelete("id")]
        public IActionResult Delete(int id)
        {
            std.DeleteStudent(id);
            return Ok("Student Deleted Successfully");
        }
    }
}
