using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Web.Mvc;
using NUnit.Framework;
using StarDestroyer.Controllers;
using Rhino.Mocks;
using MvcContrib.TestHelper;
using NBehave.Spec.NUnit;
using StarDestroyer.Core.Entities;
using StarDestroyer.Core.Repository;
using StarDestroyer.Models;
using System.Linq;

namespace StarDestroyer.Tests.Controllers
{
    public class When_searching_for_a_product : Specification
    {
        private ProductController _productController;
        private ActionResult _actionResult;
        private IProductRepository _productRepository;
        private List<Product> _fakeProducts;
        private const string PRODUCT_NAME = "SomeProductName";

        protected override void Before_each()
        {
            PrepareFakes();

            _productController = new ProductController(_productRepository);
            base.Before_each();
        }

        private void PrepareFakes()
        {
            _fakeProducts = new List<Product>() { new Product() { Description = "PIE!", ShortName = PRODUCT_NAME } };
            _productRepository = Stub<IProductRepository>();
            _productRepository.Expect(x => x.Where(Arg<Expression<Func<Product,bool>>>.Is.Anything)).Return(_fakeProducts);
        }

        protected override void Because()
        {
            _actionResult = _actionResult = _productController.Search(PRODUCT_NAME);
            base.Because();
        }

        [Test]
        public void Then_the_product_repository_should_be_queried()
        {
            _productRepository.AssertWasCalled(x => x.Where(Arg<Expression<Func<Product, bool>>>.Is.Anything));
        }

        [Test]
        public void Then_the_search_view_should_be_displayed_to_the_user()
        {
            _actionResult.AssertViewRendered().ForView("Search").WithViewData<ProductModel>();
        }

        [Test]
        public void Then_the_correct_product_should_be_displayed_to_the_user()
        {
            var productToView = ((ViewResult)_actionResult).ViewData.Model as ProductModel;
            productToView.Description.ShouldEqual("PIE!");
        }

    }
}