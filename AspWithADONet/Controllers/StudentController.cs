using AspWithADONet.Models;
using Microsoft.AspNetCore.Mvc;
using static AspWithADONet.Services.StudentServices;

namespace AspWithADONet.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentService _studentService;
        public StudentController(IStudentService studentService) { 
            _studentService = studentService;
        }
        [HttpGet]
        public IActionResult StudentList()
        { 
            AllModels model = new AllModels();
            model.studentList = _studentService.GetStudentRecord().ToList();
            return View(model);
        }
    }
}
