using Microsoft.AspNetCore.Mvc;
using Student_Interest_System_Mvc.Models;

namespace Student_Interest_System_Mvc.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            DashboardRepository dashboardRepository = new DashboardRepository();
            return View(dashboardRepository);
        }
    }
}
