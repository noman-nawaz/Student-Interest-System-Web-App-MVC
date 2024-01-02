using Microsoft.AspNetCore.Mvc;
using Student_Interest_System_Mvc.Models;

namespace Student_Interest_System_Mvc.Controllers
{
    public class DeleteStudentController : Controller
    {
        public IActionResult Index(int id)
        {
            StudentListRepository studentListRepository = new StudentListRepository();
            var student = studentListRepository.DeleteStudentById(id);

            if (student == null)
            {
                // Handle the case where the student is not found
                return NotFound();
            }
            return RedirectToAction("Index","StudentList");
        }
    }
}
