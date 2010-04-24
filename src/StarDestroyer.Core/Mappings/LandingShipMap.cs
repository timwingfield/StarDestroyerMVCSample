using FluentNHibernate.Mapping;
using StarDestroyer.Core.Entities;

namespace StarDestroyer.Core.Mappings
{
    public class LandingShipMap : ClassMap<LandingShip>
    {
        public LandingShipMap()
        {
            Id(x => x.Id);
            Map(x => x.Designation);
            Map(x => x.Deployed);
            HasManyToMany(x => x.AssaultItems)
                .Cascade
                .All()
                .Table("ShipInventory");
        }
    }
}