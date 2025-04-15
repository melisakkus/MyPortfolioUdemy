using Microsoft.AspNetCore.Mvc;
using MyPortfolioUdemy.DAL.Context;

namespace MyPortfolioUdemy.ViewComponents
{
    public class _StatisticsComponentPartial : ViewComponent
    {
        MyPortfolioContext context = new MyPortfolioContext();

        public IViewComponentResult Invoke()
        {
            ViewBag.skillCount = context.Skills.Count();
            ViewBag.messageCount = context.Messages.Count();
            ViewBag.projectCount = context.Portfolios.Count();
            ViewBag.testimonials = context.Testimonials.Count();
            return View();
        }
    }
}
