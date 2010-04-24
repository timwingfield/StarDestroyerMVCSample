using NBehave.Spec.NUnit;
using NUnit.Framework;
using StarDestroyer.Core.Entities;

namespace StarDestroyer.Tests.Entities
{
    public class When_getting_a_new_landing_craft : Specification
    {
        private LandingShip _ship;

        protected override void Because()
        {
            _ship = new LandingShip();
        }

        [Test]
        public void then_list_of_assault_items_should_not_be_null()
        {
            _ship.AssaultItems.ShouldNotBeNull();
        }

        [Test]
        public void then_list_of_assault_items_should_be_empty()
        {
            _ship.AssaultItems.Count.ShouldEqual(0);
        }
    }

    public class When_adding_the_first_assault_item_to_the_landing_craft : Specification
    {
        private AssaultItem _item;
        private LandingShip _ship;

        protected override void Before_each()
        {
            _ship = new LandingShip {Designation = "LS-1223"};
            _item = new AssaultItem {Description = "AT-ST", LoadValue = 6};
        }

        protected override void Because()
        {
            _ship.AddAssaultItem(_item);
        }

        [Test]
        public void then_the_list_of_assault_items_should_equal_one()
        {
            _ship.AssaultItems.Count.ShouldEqual(1);
        }

        [Test]
        public void then_the_list_should_contain_the_new_assault_item()
        {
            _ship.AssaultItems[0].ShouldBeTheSameAs(_item);
        }

        [Test]
        public void then_this_assault_ship_will_be_in_the_items_list_of_ships_loaded_on()
        {
            _item.LandingShipsLoadedOn[0].ShouldBeTheSameAs(_ship);
        }
    }
}