using FluentNHibernate.Mapping;
using StarDestroyer.Core.Entities;

namespace StarDestroyer.Core.Mappings
{
    public class AssaultItemMap : ClassMap<AssaultItem>
    {
        public AssaultItemMap()
        {
            Id(x => x.Id);
            Map(x => x.Type);
            Map(x => x.Description);
            Map(x => x.LoadValue);
            HasManyToMany(x => x.LandingShipsLoadedOn)
                .Cascade
                .All()
                .Inverse()
                .Table("ShipInventory");
        }
    }
}