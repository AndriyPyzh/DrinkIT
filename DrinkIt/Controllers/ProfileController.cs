
using System.Web.Mvc;

namespace DrinkIt.Controllers
{
    public class ProfileController : Controller
    {
        public ActionResult Index()
        {
            var staticPageToRender = new FilePathResult("Views/Pages/profile-page.html", "text/html");
            return staticPageToRender;
        }
    }
}