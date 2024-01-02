using Microsoft.AspNetCore.Mvc;
using Student_Interest_System_Mvc.Models;

namespace Student_Interest_System_Mvc.Controllers
{
    public class ViewStudentController : Controller
    {
        public IActionResult Index(int id)
        {


            StudentListRepository studentListRepository = new StudentListRepository();
            var student = studentListRepository.GetStudentById(id);

            if (student == null)
            {
                // Handle the case where the student is not found
                return NotFound();
            }

            // Pass the student to the view
            return View(student);
        }
    }
}
