using System.Web.Mvc;
using Core.UI.Models;

namespace Core.UI.Controllers
{
    public class SampleController : BaseController
    {
        public ActionResult EmptyForm()
        {
            return View(new SampleForm());
        }

        [HttpPost]
        public ActionResult EmptyForm(SampleForm form)
        {
            return View(form);
        }

        public ActionResult FormWithData()
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
            return View("FormWithData", form);
        }

        [HttpPost]
        public ActionResult FormWithData(SampleForm form)
        {
            form.ID = 99;
            return View(form);
        }
    }
}