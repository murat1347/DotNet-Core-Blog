using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Controllers
{
    public class NewsLatterController : Controller
    {
        private NewsLatterManager _newsLatterManager = new NewsLatterManager(new EfNewsLatterRepository());

        [HttpGet]
        public PartialViewResult SubscribeMail()
        {
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult SubscribeMail(NewsLatter newsLatter)
        {
            newsLatter.MailStatus = true;
            _newsLatterManager.AddNewsLatter(newsLatter);
            return PartialView();
        }
    }
}
