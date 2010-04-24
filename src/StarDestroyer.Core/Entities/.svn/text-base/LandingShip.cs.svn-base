using System.Collections.Generic;

namespace StarDestroyer.Core.Entities
{
    public class LandingShip
    {
        public virtual int Id { get; private set; }
        public virtual string Designation { get; set; }
        public virtual bool Deployed { get; set; }
        public virtual IList<AssaultItem> AssaultItems { get; set; }
        //public virtual IList<Pilot> Pilots { get; set; }

        public LandingShip()
        {
            AssaultItems = new List<AssaultItem>();
        }

        public virtual void AddAssaultItem(AssaultItem item)
        {
            item.LandingShipsLoadedOn.Add(this);
            AssaultItems.Add(item);
        }
    }
}