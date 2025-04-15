using Microsoft.AspNetCore.Mvc;
using MyPortfolioUdemy.DAL.Context;
using System.Linq;

namespace MyPortfolioUdemy.Controllers
{
    public class StatisticsController : Controller
    {
        MyPortfolioContext context = new MyPortfolioContext();
        public IActionResult Index()
        {
            ViewBag.skillCount = context.Skills.Count();
            ViewBag.messageCount = context.Messages.Count();
            ViewBag.notReadMessageCount = context.Messages.Where(x=>x.IsRead == false).Count();
            ViewBag.projectCount = context.Portfolios.Count();
            ViewBag.lastProject = context.Portfolios.OrderByDescending(x => x.PortfolioId).Select(x=>x.Title).FirstOrDefault();
            ViewBag.testimonials = context.Testimonials.Count();
            return View();
        }
    }
}
