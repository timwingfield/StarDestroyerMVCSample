using System.Web.Mvc;
using MvcContrib;
using MvcContrib.Attributes;
using StarDestroyer.Core.Entities;
using StarDestroyer.Core.Services;
using StarDestroyer.Models;

namespace StarDestroyer.Controllers
{
    public class InventoryController : Controller
    {
        public IInventoryService Service { get; private set; }

        public InventoryController() : this(null) { }

        public InventoryController(IInventoryService service)
        {
            Service = service ?? new InventoryService();
        }

        //public ViewResult Index()
        //{
        //    return View(new AssaultItemIndexModel {AssaultItems = Service.GetAllAssaultItems()});
        //}

        public ViewResult Index(string message)
        {
            var model = new AssaultItemIndexModel
                            {
                                AssaultItems = Service.GetAllAssaultItems(), 
                                Message = message
                            };

            return View(model);
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult Details(int? id)
        {
            if (!id.HasValue) return RedirectToAction("Index");

            var model = Service.GetAssaultItemById(id.Value).ToDetailModel();

            return View(model);
        }

        //First Ajax Details
        //[AcceptPost]
        //public ContentResult AjaxDetails(int? id)
        //{
        //    return Content(Service.GetAssaultItemById(id.Value).ToDetailModel().ToDetailHtml());
        //}

        //Second Ajax Details
        [AcceptPost]
        public PartialViewResult AjaxDetails(int? id)
        {
            return PartialView("InventoryDetails", Service.GetAssaultItemById(id.Value).ToDetailModel());
        }

        [AcceptGet]
        public ViewResult Edit(int id)
        {
            return View(Service.GetAssaultItemById(id).ToAssaultItemEditModel());
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Save(AssaultItemEditModel item)
        {
            //do save
            var assaultItem = new AssaultItem(item.Id)
                                  {
                                      Description = item.Description, 
                                      Type = item.Type, 
                                      LoadValue = item.LoadValue
                                  };

            Service.SaveAssaultItem(assaultItem);

            var message = "Item saved successfully.";

            return this.RedirectToAction(x => x.Index(message));
        }
    }
}