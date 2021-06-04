using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Raintels.Entity.ViewModel;
using Raintels.Service.ServiceInterface;

namespace Raintels.Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly ILogger<StudentController> logger;
        private readonly IStudentService studentService;
        public StudentController(ILogger<StudentController> _logger, IStudentService _studentService)
        {
            logger = _logger;
            studentService = _studentService;
        }

        [HttpGet("getall")]
        public IEnumerable<StudentViewModel> GetAllStudents()
        {
            return studentService.GetStudents().Result;
        }

        [HttpGet("getbyid/{studentId}")]
        public StudentViewModel GetStudent(int studentId)
        {
            return studentService.GetStudentDetailsById(studentId).Result;
        }

        [HttpPost("savestudent")]
        public void SaveStudent(StudentViewModel student)
        {
            studentService.CreateStudent(student);
        }

        [HttpPost("updatestudent")]
        public void UpdateStudent(StudentViewModel student)
        {
            studentService.UpdateStudent(student);
        }

        [HttpGet("delete/{studentId}")]
        public void DeleteStudent(int studentId)
        {
            studentService.DeleteStudent(studentId);
        }
    }
}
