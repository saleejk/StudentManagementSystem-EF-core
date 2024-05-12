using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentManagementSystem_EF_core.ModelEntity;
using StudentManagementSystem_EF_core.Service;

namespace StudentManagementSystem_EF_core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudent _iStudent;
        public StudentController(IStudent istudent)
        {
            _iStudent= istudent;
        }

      [HttpGet("ALL")]
     public IActionResult Get()
      {
            return Ok(_iStudent.GetAllStudents());

      }

        [HttpGet("by id")]
        public IActionResult GetByID(int id)
        {
            return Ok(_iStudent.GetStudentById(id));
        }
        [HttpGet("By Filtering Age")]
        public IActionResult FilterByAge(int Age)
        {
            return Ok(_iStudent.FilterStudentByAge(Age));
        }
        [HttpGet("Search")]
        public IActionResult Search(string name)
        {
            return Ok(_iStudent.SearchStudentByName(name));
        }
        [HttpPost]
        public IActionResult AddStdnt(Student students)
        {
            _iStudent.AddStudent(students);
            return Ok("ADDED SCCESSFULLY");
        }
        [HttpPut("ALL")]
        public IActionResult UpdateAll(Student students)
        {
            _iStudent.UpdateStudent(students);
            return Ok("UPDATED SUCCESSFULLY");
        }
        [HttpPut("AGE")]
        public IActionResult Updateid(int id, int age)
        {
            _iStudent.UpdateAge(id, age);
            return Ok("AGE CHANGED SUCCESFULLYYY");
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            _iStudent.DeleteStudent(id);
            return Ok("Record Deleted Successfully");
        }









    }
}
