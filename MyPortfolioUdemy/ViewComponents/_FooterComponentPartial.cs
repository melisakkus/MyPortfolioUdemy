using Microsoft.AspNetCore.Mvc;
using MyPortfolioUdemy.DAL.Context;

namespace MyPortfolioUdemy.ViewComponents
{
    public class _FooterComponentPartial : ViewComponent
    {
        MyPortfolioContext portfolioContext = new MyPortfolioContext();

        public IViewComponentResult Invoke()
        {
            var socialMediaList = portfolioContext.SocialMedias.ToList();
            return View(socialMediaList);
        }
    }
}
