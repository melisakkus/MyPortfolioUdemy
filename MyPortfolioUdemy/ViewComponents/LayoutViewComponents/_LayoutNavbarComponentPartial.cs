using Microsoft.AspNetCore.Mvc;
using MyPortfolioUdemy.DAL.Context;

namespace MyPortfolioUdemy.ViewComponents.LayoutViewComponents
{
	public class _LayoutNavbarComponentPartial : ViewComponent
	{
        MyPortfolioContext context = new MyPortfolioContext();
        public IViewComponentResult Invoke()
		{
			var values = context.ToDoLists.Where(x=>x.Status==false).ToList();
			ViewBag.count = context.ToDoLists.Where(x => x.Status==false).Count();
            return View(values);
		}
	}
}
