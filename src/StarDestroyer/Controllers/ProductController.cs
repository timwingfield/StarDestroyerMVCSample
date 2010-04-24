using System;
using System.Collections.Generic;
using System.Web.Mvc;
using MvcContrib.Attributes;
using StarDestroyer.Core.Entities;
using StarDestroyer.Core.Helpers;
using StarDestroyer.Core.Repository;
using StarDestroyer.Helpers.Filters;
using StarDestroyer.Models;
using System.Linq;
using StarDestroyer.Models;

namespace StarDestroyer.Controllers
{
    public class ProductController : Controller
    {
        private IProductRepository _productRepository;

        public ProductController()
            : this(null)
        {

        }

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository ?? new ProductRepository();
        }

        [RequiresSuggestionsFilter]
        public ActionResult Search(string productName)
        {
            var product = _productRepository.Where(x => x.ShortName == productName).FirstOrDefault();

            return View("Search", product.ToProductModel());
        }

        [AcceptGet()]
        public ActionResult List(JQGridRequestModel gridRequest)
        {
            var searchResult = _productRepository.SearchProducts(new SearchParameters()
                  {
                      Ascending = gridRequest.sord == "asc" ? true : false,
                      Count = gridRequest.rows,
                      Page = gridRequest.page,
                      SortColumn = gridRequest.sidx
                  });

            var jsonData = new
               {
                   total = searchResult.Count,
                   page = gridRequest.page,
                   records = gridRequest.rows,
                   rows = (searchResult.Items.Select(x => new { id = x.Id, cell = new string[] { x.Name, x.Price.ToString(), x.InStock.ToString() } }))
               };
            return Json(jsonData);
        }

        [AcceptGet()]
        public ActionResult Catalog()
        {
            var products = _productRepository.GetAll();
            return View(products.ToProductListingModel());
        }

    }
}