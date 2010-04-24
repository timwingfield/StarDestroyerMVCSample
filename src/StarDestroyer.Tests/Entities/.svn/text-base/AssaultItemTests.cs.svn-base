using NBehave.Spec.NUnit;
using NUnit.Framework;
using StarDestroyer.Core.Entities;

namespace StarDestroyer.Tests.Entities
{
    public class When_getting_a_new_assult_item : Specification
    {
        private AssaultItem _item;

        protected override void Because()
        {
            _item = new AssaultItem();
        }

        [Test]
        public void then_inventories_list_is_not_null()
        {
            _item.LandingShipsLoadedOn.ShouldNotBeNull();
        }

        [Test]
        public void then_inventories_list_is_empty()
        {
            _item.LandingShipsLoadedOn.Count.ShouldEqual(0);
        }
    }
}