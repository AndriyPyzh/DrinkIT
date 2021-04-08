using System.Web.Mvc;

namespace DrinkIt.Controllers
{
    public class WelcomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}