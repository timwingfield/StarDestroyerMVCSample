using System.Web.Routing;
using MvcContrib.TestHelper;
using NUnit.Framework;
using StarDestroyer.Controllers;

namespace StarDestroyer.Tests.Routes
{
    public class When_accessing_urls_for_the_star_destroyer_mvc_app : Specification
    {
        protected override void Before_each()
        {
            MvcApplication.RegisterRoutes(RouteTable.Routes);
            base.Before_each();
        }

        protected override void After_each()
        {
            RouteTable.Routes.Clear();
            base.After_each();
        }

        [Test]
        public void Should_map_blank_url_to_home()
        {
            "~/".Route().ShouldMapTo<HomeController>(c => c.Index());
        }

        [Test]
        public void Should_map_inventory_details_to_inventory_controller_and_details_action()
        {
            "~/inventory/edit/1".Route().ShouldMapTo<InventoryController>(c => c.Edit(1));
        }

        [Test]
        public void The_default_action_for_controllers_should_be_index()
        {
            "~/inventory".Route().ShouldMapTo<InventoryController>(c => c.Index(null));
        }

        [Test]
        public void Product_searches_should_map_to_the_product_search_action()
        {
            "~/Something".Route().ShouldMapTo<ProductController>(c => c.Search("Something"));
        }

        [Test]
        public void Requests_on_the_product_controller_should_be_default_route_if_not_searching_by_product()
        {
            "~/Product/Catalog".Route().ShouldMapTo<ProductController>(c => c.Catalog());
        }
    }
}