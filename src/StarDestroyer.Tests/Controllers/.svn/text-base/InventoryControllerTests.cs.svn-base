using System;
using System.Collections.Generic;
using System.Web.Mvc;
using NBehave.Spec.NUnit;
using NUnit.Framework;
using Rhino.Mocks;
using StarDestroyer.Controllers;
using StarDestroyer.Core.Entities;
using StarDestroyer.Core.Services;
using StarDestroyer.Models;
using MvcContrib.TestHelper;

namespace StarDestroyer.Tests.Controllers
{
    public class When_calling_the_constructor_with_an_iiservice_parameter : Specification
    {
        InventoryController _controller;
        private IInventoryService _service;

        protected override void Before_each()
        {
            _service = Stub<IInventoryService>();
        }

        protected override void Because()
        {
            _controller = new InventoryController(_service);
        }

        [Test]
        public void then_the_inventory_service_should_be_the_same_as_the_one_passed_in()
        {
            _controller.Service.ShouldBeTheSameAs(_service);
        }
    }

    public class When_calling_index_on_the_inventory_controller : Specification
    {
        private ViewResult _result;
        private object _viewData;
        private InventoryController _controller;
        private IList<AssaultItem> _aiList;
        private IInventoryService _service;

        protected override void Before_each()
        {
            _aiList = new List<AssaultItem>
                          {
                              new AssaultItem {Description = "Stormtrooper"},
                              new AssaultItem {Description = "AT-ST"}
                          };
            _service = Stub<IInventoryService>();
            _service.Stub(x => x.GetAllAssaultItems()).Return(_aiList);

            _controller = new InventoryController(_service);
        }

        protected override void Because()
        {
            _result = _controller.Index(string.Empty);
            _viewData = _result.ViewData.Model;
        }

        [Test]
        public void then_a_view_should_be_returned()
        {
            _result.ShouldNotBeNull();
        }

        [Test]
        public void then_the_view_model_should_be_of_type_assault_item_index_model()
        {
            _viewData.GetType().ShouldEqual(typeof(AssaultItemIndexModel));
        }

        [Test]
        public void then_model_message_should_be_empty()
        {
            String.IsNullOrEmpty(((AssaultItemIndexModel)_viewData).Message).ShouldBeTrue();
        }

        [Test]
        public void then_get_all_assault_items_should_be_called_on_the_service()
        {
            _service.AssertWasCalled(x => x.GetAllAssaultItems());
        }
    }
    public class When_calling_index_on_the_inventory_controller_with_a_message : Specification
    {
        private ViewResult _result;
        private object _viewData;
        private InventoryController _controller;
        private IList<AssaultItem> _aiList;
        private IInventoryService _service;
        private string _message;

        protected override void Before_each()
        {
            _aiList = new List<AssaultItem>
                          {
                              new AssaultItem {Description = "Stormtrooper"},
                              new AssaultItem {Description = "AT-ST"}
                          };
            _service = Stub<IInventoryService>();
            _service.Stub(x => x.GetAllAssaultItems()).Return(_aiList);

            _controller = new InventoryController(_service);
            _message = "My Message";
        }

        protected override void Because()
        {
            _result = _controller.Index(_message);
            _viewData = _result.ViewData.Model;
        }

        [Test]
        public void then_a_view_should_be_returned()
        {
            _result.ShouldNotBeNull();
        }

        [Test]
        public void then_the_view_model_should_be_of_type_assault_item_index_model()
        {
            _viewData.GetType().ShouldEqual(typeof(AssaultItemIndexModel));
        }

        [Test]
        public void then_model_message_should_be_my_message()
        {
            ((AssaultItemIndexModel)_viewData).Message.ShouldEqual(_message);
        }

        [Test]
        public void then_get_all_assault_items_should_be_called_on_the_service()
        {
            _service.AssertWasCalled(x => x.GetAllAssaultItems());
        }
    }

    public class When_calling_the_details_action_without_an_id : Specification
    {
        private RedirectToRouteResult _result;
        private InventoryController _controller;
        private IInventoryService _service;

        protected override void Before_each()
        {
            _service = Stub<IInventoryService>();
            _controller = new InventoryController(_service);
        }

        protected override void Because()
        {
            _result = _controller.Details(null) as RedirectToRouteResult;
        }

        [Test]
        public void then_the_controller_should_redirect_to_the_index_action()
        {
            _result.RouteValues["action"].ShouldEqual("Index");
        }

        [Test]
        public void then_get_assault_item_by_id_is_not_called_on_the_controller()
        {
            _service.AssertWasNotCalled(x => x.GetAssaultItemById(2));
        }
    }

    public class When_calling_the_details_action_with_an_id : Specification
    {
        private ViewResult _result;
        private object _viewData;
        private InventoryController _controller;
        private IInventoryService _service;
        private AssaultItem _item;

        protected override void Before_each()
        {
            _item = new AssaultItem {Description = "AT-AT", LoadValue = 72};
            _service = Stub<IInventoryService>();
            _service.Stub(x => x.GetAssaultItemById(2)).Return(_item);

            _controller = new InventoryController(_service);
        }

        protected override void Because()
        {
            _result = (ViewResult) _controller.Details(2);
            _viewData = _result.ViewData.Model;
        }

        [Test]
        public void then_a_view_should_be_returned()
        {
            _result.ShouldNotBeNull();
        }

        [Test]
        public void then_the_view_model_should_be_of_type_assault_item_detail_model()
        {
            _viewData.GetType().ShouldEqual(typeof(AssaultItemDetailModel));
        }

        [Test]
        public void then_get_assault_item_by_id_is_called_on_the_service()
        {
            _service.AssertWasCalled(x => x.GetAssaultItemById(2));
        }
    }

    public class When_converting_an_assault_item_to_an_assault_item_detail_model : Specification
    {
        private AssaultItem _item;
        private AssaultItemDetailModel _model;

        protected override void Before_each()
        {
            _item = new AssaultItem {Description = "Some Description", Type = "Lame Troopers", LoadValue = 4};
        }

        protected override void Because()
        {
            _model = _item.ToDetailModel();
        }

        [Test]
        public void then_type_is_set()
        {
            _model.Type.ShouldEqual(_item.Type);
        }

        [Test]
        public void then_description_is_set()
        {
            _model.Description.ShouldEqual(_item.Description);
        }

        [Test]
        public void then_load_value_is_set()
        {
            _model.LoadValue.ShouldEqual(_item.LoadValue);
        }

        [Test]
        public void then_images_list_is_not_null()
        {
            _model.Images.ShouldNotBeNull();
        }

        [Test]
        public void then_images_list_is_empty()
        {
            _model.Images.Count.ShouldEqual(0);
        }
    }

    public class When_converting_an_assault_item_to_an_assault_item_detail_model_and_setting_up_images : Specification
    {
        private AssaultItem _item;
        private AssaultItemDetailModel _model;

        protected override void Before_each()
        {
            _item = new AssaultItem { Description = "Dark Troopers, stormtroopers, SHOCK troopers, sCOUt troopers, at-st, Speeder BIKE, Heavy blaster"};
        }

        protected override void Because()
        {
            _model = _item.ToDetailModel();
        }

        [Test]
        public void then_images_list_will_have_seven_items()
        {
            _model.Images.Count.ShouldEqual(7);
        }

        [Test]
        public void then_the_images_list_should_contain_the_shock_trooper_icon()
        {
            _model.Images.ShouldContain("Shock_trooper_icon.png");
        }
    }

    public class When_calling_the_AjaxDetails_action_with_an_id : Specification
    {
        private PartialViewResult _result;
        private InventoryController _controller;
        private IInventoryService _service;
        private AssaultItem _item;

        protected override void Before_each()
        {
            _item = new AssaultItem
                        {
                            Description = "Dark Trooper squad with 7 dark troopers",
                            LoadValue = 4,
                            Type = "Dark Trooper Squad"
                        };

            _service = Stub<IInventoryService>();
            _service.Stub(x => x.GetAssaultItemById(2)).Return(_item);

            _controller = new InventoryController(_service);
        }

        protected override void Because()
        {
            _result = _controller.AjaxDetails(2);
        }

        [Test]
        public void then_get_assault_item_by_id_is_called_on_the_service()
        {
            _service.AssertWasCalled(x => x.GetAssaultItemById(2));
        }

        [Test]
        public void then_a_partial_view_should_be_returned()
        {
            _result.AssertPartialViewRendered().ForView("InventoryDetails").WithViewData<AssaultItemDetailModel>();
        }

        [Test]
        public void then_the_view_model_should_be_of_type_AssaultItemDetailModel()
        {
            _result.ViewData.Model.ShouldBeInstanceOfType(typeof(AssaultItemDetailModel));
        }

        [Test]
        public void then_the_content_should_contain_html_for_an_image()
        {
            ((AssaultItemDetailModel)_result.ViewData.Model).Images.Contains("Dark_trooper_icon.png").ShouldBeTrue();
        }

        [Test]
        public void then_the_content_should_contain_html_for_a_description()
        {
            ((AssaultItemDetailModel) _result.ViewData.Model).Description.ShouldEqual(_item.Description);
        }
    }

    public class When_translating_an_assault_item_detail_model_to_a_string_of_html : Specification
    {
        private AssaultItemDetailModel _model;
        private string _html;

        protected override void Before_each()
        {
            _model = new AssaultItemDetailModel
                         {
                             Description = "My Description",
                             LoadValue = 4,
                             Type = "My Type",
                             Images = new List<string> {"Dark_trooper_icon.png"}
                         };
        }

        protected override void Because()
        {
            _html = _model.ToDetailHtml();
        }

        [Test]
        public void then_the_string_should_contain_an_image_tag()
        {
            _html.Contains("<img src=\"../../Content/Images/").ShouldBeTrue();
        }

        [Test]
        public void then_the_string_should_contain_a_ul()
        {
            _html.Contains("</ul>").ShouldBeTrue();
        }

        [Test]
        public void then_the_string_should_contain_a_li()
        {
            _html.Contains("<li>").ShouldBeTrue();
        }

        [Test]
        public void then_the_string_should_contain_the_type_formatted_as_name_value()
        {
            _html.Contains("<li><strong>Type:</strong> My Type</li>").ShouldBeTrue();
        }

        [Test]
        public void then_the_string_should_contain_the_load_value_formatted_as_name_value()
        {
            _html.Contains("<li><strong>Load Value:</strong> 4</li>").ShouldBeTrue();
        }
    }

    public class When_calling_the_edit_get_method_on_the_controller : Specification
    {
        private InventoryController _controller;
        private IInventoryService _service;
        private AssaultItem _item;
        private ViewResult _result;
        private object _viewData;

        protected override void Before_each()
        {
            _item = new AssaultItem { Description = "AT-AT", LoadValue = 72 };
            _service = Stub<IInventoryService>();
            _service.Stub(x => x.GetAssaultItemById(2)).Return(_item);

            _controller = new InventoryController(_service);
        }

        protected override void Because()
        {
            _result = _controller.Edit(2);
            _viewData = _result.ViewData.Model;
        }

        [Test]
        public void then_a_view_should_be_returned()
        {
            _result.ShouldNotBeNull();
        }

        [Test]
        public void then_get_assault_item_by_id_should_be_called_on_the_service()
        {
            _service.AssertWasCalled(x => x.GetAssaultItemById(2));
        }

        [Test]
        public void then_the_model_is_of_type_assault_item_edit_model()
        {
            _viewData.GetType().ShouldEqual(typeof(AssaultItemEditModel));
        }
    }

    public class When_calling_save_on_the_controller_with_an_existing_object : Specification
    {
        [Test]
        public void then_save_assault_item_is_called_on_the_service()
        {
            
        }
    }

    public class When_converting_an_assault_item_to_an_assault_item_edit_model : Specification
    {
        private AssaultItem _item;
        private AssaultItemEditModel _model;

        protected override void Before_each()
        {
            _item = new AssaultItem(2){Description = "my description", Type = "my type", LoadValue = 4};
        }

        protected override void Because()
        {
            _model = _item.ToAssaultItemEditModel();
        }

        [Test]
        public void then_the_id_should_be_set()
        {
            _model.Id.ShouldEqual(_item.Id);
        }

        [Test]
        public void then_the_description_should_be_set()
        {
            _model.Description.ShouldEqual(_item.Description);
        }

        [Test]
        public void then_the_type_should_be_set()
        {
            _model.Type.ShouldEqual(_item.Type);
        }

        [Test]
        public void then_the_load_value_should_be_set()
        {
            _model.LoadValue.ShouldEqual(_item.LoadValue);
        }
    }
}