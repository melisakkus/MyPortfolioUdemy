using Microsoft.AspNetCore.Mvc;
using MyPortfolioUdemy.DAL.Context;
using MyPortfolioUdemy.DAL.Entities;

namespace MyPortfolioUdemy.Controllers
{
    public class PortfolioController : Controller
    {
        MyPortfolioContext context = new MyPortfolioContext();
        public IActionResult Index()
        {
            var values = context.Portfolios.ToList();
            return View(values);
        }

        public IActionResult Delete(int id)
        {
            var value = context.Portfolios.Find(id);
            context.Portfolios.Remove(value);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var value = context.Portfolios.Find(id);
            return View(value);
        }
        [HttpPost]
        public IActionResult Update(Portfolio portfolio)
        {
            context.Portfolios.Update(portfolio);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Portfolio portfolio)
        {
            context.Portfolios.Add(portfolio);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
