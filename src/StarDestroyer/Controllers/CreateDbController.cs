using System.Web.Mvc;
using StarDestroyer.Core.Services;

namespace StarDestroyer.Controllers
{
    public class CreateDbController : Controller
    {
        //
        // GET: /CreateDb/

        public ActionResult Index()
        {
            var _service = new CreateDbService();
            var dbCreated = _service.CreateDb();
            ViewData["Message"] = string.Format("Database created. Assault Items added: {0}", dbCreated);
            return View();
        }

    }
}
