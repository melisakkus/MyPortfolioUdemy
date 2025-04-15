using Microsoft.AspNetCore.Mvc;
using MyPortfolioUdemy.DAL.Context;
using MyPortfolioUdemy.DAL.Entities;

namespace MyPortfolioUdemy.Controllers
{
    public class ExperienceController : Controller
    {
        MyPortfolioContext portfolioContext = new MyPortfolioContext();
        public IActionResult Index()
        {
            var values = portfolioContext.Experiences.ToList();
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateExperience()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateExperience(Experience experience)
        {
            portfolioContext.Experiences.Add(experience);
            portfolioContext.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult DeleteExperience(int id)
        {
            var experience = portfolioContext.Experiences.Find(id);
            portfolioContext.Experiences.Remove(experience);
            portfolioContext.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateExperience(int id)
        {
            var experience = portfolioContext.Experiences.Find(id);
            return View(experience);
        }

        [HttpPost]
        public IActionResult UpdateExperience(Experience experience)
        {
            portfolioContext.Experiences.Update(experience);
            portfolioContext.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
