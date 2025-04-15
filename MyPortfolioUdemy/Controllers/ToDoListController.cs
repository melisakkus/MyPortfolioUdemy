using Microsoft.AspNetCore.Mvc;
using MyPortfolioUdemy.DAL.Context;
using MyPortfolioUdemy.DAL.Entities;

namespace MyPortfolioUdemy.Controllers
{
    public class ToDoListController : Controller
    {
        MyPortfolioContext context = new MyPortfolioContext();
        public IActionResult Index()
        {
            var values = context.ToDoLists.OrderByDescending(x=>x.Date).ToList();
            return View(values);
        }

        public IActionResult Delete(int id)
        {
            var value = context.ToDoLists.Find(id);
            context.ToDoLists.Remove(value);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var value = context.ToDoLists.Find(id);
            return View(value);
        }
        [HttpPost]
        public IActionResult Update(ToDoList toDoList)
        {
            context.ToDoLists.Update(toDoList);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(ToDoList toDoList)
        {
            toDoList.Status = false;
            context.ToDoLists.Add(toDoList);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult StatusDone(int id)
        {
            var value = context.ToDoLists.Find(id);
            value.Status = true;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult StatusNotDone(int id)
        {
            var value = context.ToDoLists.Find(id);
            value.Status = false;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
