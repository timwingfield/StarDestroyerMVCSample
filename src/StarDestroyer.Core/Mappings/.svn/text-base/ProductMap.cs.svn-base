using FluentNHibernate.Mapping;
using StarDestroyer.Core.Entities;

namespace StarDestroyer.Core.Mappings
{
    public class ProductMap : ClassMap<Product>
    {
        public ProductMap()
        {
            Id(x => x.Id);
            Map(x => x.Description);
            Map(x => x.Name);
            Map(x => x.InStock);
            Map(x => x.Price);
            Map(x => x.ShortName);
        }
    }
}