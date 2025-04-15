using Microsoft.AspNetCore.Mvc;
using MyPortfolioUdemy.DAL.Context;
using MyPortfolioUdemy.DAL.Entities;

namespace MyPortfolioUdemy.Controllers
{
    public class SocialMediaController : Controller
    {
        MyPortfolioContext context = new MyPortfolioContext();
        public IActionResult Index()
        {
            var values = context.SocialMedias.ToList();
            return View(values);
        }

        public IActionResult Delete(int id)
        {
            var value = context.SocialMedias.Find(id);
            context.SocialMedias.Remove(value);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var value = context.SocialMedias.Find(id);
            return View(value);
        }
        [HttpPost]
        public IActionResult Update(SocialMedia socialMedia)
        {
            context.SocialMedias.Update(socialMedia);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(SocialMedia socialMedias)
        {
            context.SocialMedias.Add(socialMedias);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
