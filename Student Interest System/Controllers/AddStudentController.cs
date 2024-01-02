using Microsoft.AspNetCore.Mvc;
using Student_Interest_System_Mvc.Models;

namespace Student_Interest_System_Mvc.Controllers
{
    public class AddStudentController : Controller
    {
        public IActionResult Index()
        {
            StudentRepository studentRepository = new StudentRepository();

            ViewBag.InterestsFromDatabase = studentRepository.GetInterestsFromDatabase();
            return View();
        }

        [HttpPost]
        public IActionResult Index(Student student)
        {
            StudentRepository studentRepository = new StudentRepository();
            if (ModelState.IsValid)
            {
                studentRepository.AddStudent(student);

                
                ViewBag.InterestsFromDatabase = studentRepository.GetInterestsFromDatabase();
                return RedirectToAction("Index","StudentList");
            }
            else
            {
                
                ViewBag.InterestsFromDatabase = studentRepository.GetInterestsFromDatabase();
                return View("Index", student);
            }
        }

    }
}
