using Microsoft.AspNetCore.Mvc;

namespace MyPortfolioUdemy.Controllers
{
    public class LayoutController : Controller
    {
        public IActionResult Layout()
        {
            return View();
        }
    }
}
