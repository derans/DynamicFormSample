using System.Web.Mvc;
using Core.UI.Models;

namespace Core.UI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var formWithData = new SampleForm
            {
                FirstName = "Han",
                LastName = "Solo",
                EmailAddress = "han@solo.com",
                FavoriteColors = new[] { "blue", "green", "gray" },
                FavoriteNumbers = new[] { 1, 2, 3, 4, 5 }
            };

            return View(formWithData);
        }

        public ActionResult GetFormWithData(SampleForm form)
        {
            form.ID = 99;
            return View("Index", form);
        }

        [HttpPost]
        public ActionResult Index(SampleForm form)
        {
            form.ID = 99;
            return View(form);
        }
    }
}