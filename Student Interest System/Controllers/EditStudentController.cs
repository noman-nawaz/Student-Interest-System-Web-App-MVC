using Microsoft.AspNetCore.Mvc;
using Student_Interest_System_Mvc.Models;

namespace Student_Interest_System_Mvc.Controllers
{
    public class EditStudentController : Controller
    {
        public IActionResult Index(int id)
        {
            StudentListRepository studentListRepository = new StudentListRepository();
            StudentRepository studentRepository = new StudentRepository();

            ViewBag.InterestsFromDatabase = studentRepository.GetInterestsFromDatabase();
            var student = studentListRepository.GetStudentById(id);
            if (student == null)
            {               
                return NotFound();
            }          
            return View(student);
        }

        [HttpPost]
        public IActionResult Index(Student student)
        {
            StudentListRepository studentListRepository = new StudentListRepository();
            studentListRepository.UpdateStudent(student);
            return RedirectToAction("Index","StudentList");
        }
    }
}
