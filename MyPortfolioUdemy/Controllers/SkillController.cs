using Microsoft.AspNetCore.Mvc;
using MyPortfolioUdemy.DAL.Context;
using MyPortfolioUdemy.DAL.Entities;

namespace MyPortfolioUdemy.Controllers
{
    public class SkillController : Controller
    {
        MyPortfolioContext context = new MyPortfolioContext();
        public IActionResult Index()
        {
            var values = context.Skills.ToList();
            return View(values);
        }

        public IActionResult Delete(int id)
        {
            var value = context.Skills.Find(id);
            context.Skills.Remove(value);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var value = context.Skills.Find(id);
            return View(value);
        }
        [HttpPost]
        public IActionResult Update(Skill skill)
        {
            context.Skills.Update(skill);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Skill skill)
        {
            context.Skills.Add(skill);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
