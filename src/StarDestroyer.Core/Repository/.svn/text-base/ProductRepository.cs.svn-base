using System;
using System.Linq.Expressions;
using StarDestroyer.Core.Entities;
using StarDestroyer.Core.Helpers;
using NHibernate.Linq;
using System.Linq;
using System.Linq.Dynamic;

namespace StarDestroyer.Core.Repository
{
    public interface IProductRepository : IRepository<Product>
    {
        PagedSearchResult<Product> SearchProducts(SearchParameters searchParams);
    }

    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository() : base(CreateSessionFactory()) { }

        public PagedSearchResult<Product> SearchProducts(SearchParameters searchParams)
        {
            var searchResult = new PagedSearchResult<Product>();
            using (var session = _sessionFactory.OpenSession())
            {
                var source = session.Linq<Product>();
                searchResult.Count = source.Count();

                var query = (searchParams.Ascending ? "asc" : "desc");

                searchResult.Items = source.OrderBy(searchParams.SortColumn + " " + query)
                    .Skip((searchParams.Page - 1) * searchParams.Count)
                    .Take(searchParams.Count).ToList();
            }

            return searchResult;
        }
    }
}