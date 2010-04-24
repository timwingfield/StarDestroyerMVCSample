using System;
using System.Collections.Generic;
using System.Web.Mvc;
using NUnit.Framework;
using StarDestroyer.Helpers.Filters;
using Rhino.Mocks;
using NBehave.Spec.NUnit;
using MvcContrib;
using System.Linq;
using StarDestroyer.Models;

namespace StarDestroyer.Tests.Filters
{
    public class When_requiring_suggested_products : Specification
    {
        protected ActionExecutingContext _actionExecutingContext;
        protected ISuggestionRepository _suggestionRepository;
        protected List<ProductModel> _fakeProducts;
        protected RequiresSuggestionsFilterAttribute _filterToTest;

        protected override void Before_each()
        {
            CreateFakes();
            _filterToTest = new RequiresSuggestionsFilterAttribute(_suggestionRepository);
            base.Before_each();
        }

        protected override void Because()
        {
            _filterToTest.OnActionExecuting(_actionExecutingContext);
            base.Because();
        }

        private void CreateFakes()
        {
            _fakeProducts = new List<ProductModel>()
                                {
                                    new ProductModel(){Description = "cherry", Name = "pie"}
                                };
            _suggestionRepository = Stub<ISuggestionRepository>();
            _suggestionRepository.Stub(x => x.GetSuggestedProducts()).Return(_fakeProducts);
            _actionExecutingContext = new ActionExecutingContext { Controller = Stub<ControllerBase>() };
            _actionExecutingContext.Controller.ViewData = Stub<ViewDataDictionary>();
        }

        [Test]
        public void Then_the_suggestion_repository_should_be_queried_to_display_suggestions()
        {
            //Couldn't seem to get the ViewData extension "Get" to show up here. ???
            _actionExecutingContext.Controller.ViewData.Values.FirstOrDefault().ShouldEqual(_fakeProducts);
        }
    }
}