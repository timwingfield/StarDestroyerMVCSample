using System.Web.Mvc;
using System.Web.Routing;
using StarDestroyer.Models;

namespace StarDestroyer.Controllers
{
    public class AssaultController : Controller
    {
        public ActionResult Index()
        {
            var model = new AssaultShipIndexModel();
            model.PartialOne = new PartialRequest(new { action = "PartialViewOne", controller = "Assault" });
            model.PartialB = new PartialRequest(new { action = "PartialViewB", controller = "Assault" });
            return View(model);
        }

        public ViewResult PartialViewOne()
        {
            return View("PartialViewOne");
        }

        public ViewResult PartialViewB()
        {
            return View();
        }
    }
}