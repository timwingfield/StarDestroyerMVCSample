using System.Web.Mvc;
using NUnit.Framework;
using NBehave.Spec.NUnit;
using StarDestroyer.Controllers;
namespace StarDestroyer.Tests.Controllers
{
    public class HomeControllerTest : Specification
    {

        //[Test]
        //public void About()
        //{
        //    // Arrange
        //    HomeController controller = new HomeController();

        //    // Act
        //    ViewResult result = controller.About() as ViewResult;

        //    // Assert
        //    Assert.IsNotNull(result);
        //}
    }



    public class When_calling_index_on_the_home_controller : Specification
    {
        private HomeController _controller;
        private ViewResult _result;
        private ViewDataDictionary _viewData;

        protected override void Before_each()
        {
            _controller = new HomeController();
        }

        protected override void Because()
        {
            _result = _controller.Index() as ViewResult;
            _viewData = _result.ViewData;
        }

        [Test]
        public void then_view_data_contains_welcome_string()
        {
            _viewData["Message"].ShouldBeTheSameAs("Welcome to ASP.NET MVC!");
        }
        
    }

    public class When_calling_about_on_the_home_controller : Specification
    {
        private ViewResult _viewResult;
        private HomeController _controller;

        protected override void Before_each()
        {
            _controller = new HomeController();    
        }

        protected override void Because()
        {
            _viewResult = _controller.About() as ViewResult;
        }

        [Test]
        public void the_view_result_is_not_null()
        {
            _viewResult.ShouldNotBeNull();

        }
    }

    public class When_testing_nbehave_spec_base : SpecBase
    {
        private HomeController _controller;
        private ViewResult _result;

        protected override void Establish_context()
        {
            _controller = new HomeController();
        }

        protected override void Because_of()
        {
            _result = _controller.About() as ViewResult;
        }

        [Test]
        public void then_the_view_result_should_not_be_null()
        {
            _result.ShouldNotBeNull();
        }
    }
}
