using Microsoft.AspNetCore.Mvc;
using Student_Interest_System_Mvc.Models;

namespace Student_Interest_System_Mvc.Controllers
{
    public class StudentListController : Controller
    {
        public IActionResult Index()
        {
            StudentListRepository studentListRepository = new StudentListRepository();
            
            return View(studentListRepository.GetAllStudents());
        }
    }
}
