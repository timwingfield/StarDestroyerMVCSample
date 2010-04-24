using System.Collections.Generic;

namespace StarDestroyer.Core.Entities
{
    public class AssaultItem
    {
        public virtual int Id { get; private set; }
        public virtual string Type { get; set; }
        public virtual string Description { get; set; }
        public virtual int LoadValue { get; set; }

        public virtual IList<LandingShip> LandingShipsLoadedOn {get; private set;}

        public AssaultItem()
        {
            LandingShipsLoadedOn = new List<LandingShip>();
        }
        
        public AssaultItem(int id)
        {
            Id = id;
            LandingShipsLoadedOn = new List<LandingShip>();
        }
    }
}