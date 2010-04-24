using System.Collections.Generic;
using System.IO;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NBehave.Spec.NUnit;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using NUnit.Framework;
using StarDestroyer.Core.Entities;
using StarDestroyer.Core.Helpers;
using StarDestroyer.Core.Repository;

namespace StarDestroyer.Tests.Integration
{
    public class And_setting_up_the_temporary_database : Specification
    {
        private const string DbFile = "integrationTest.db";

        public static ISessionFactory CreateSessionFactory()
        {
            return Fluently.Configure()
                .Database(SQLiteConfiguration.Standard
                    .UsingFile(DbFile))
                .Mappings(m =>
                    m.FluentMappings.AddFromAssemblyOf<AssaultItem>())
                .BuildSessionFactory();
        }

        public static ISessionFactory CreateBuildSessionFactory()
        {
            return Fluently.Configure()
                .Database(SQLiteConfiguration.Standard
                    .UsingFile(DbFile))
                .Mappings(m =>
                    m.FluentMappings.AddFromAssemblyOf<AssaultItem>())
                .ExposeConfiguration(BuildSchema)
                .BuildSessionFactory();
        }

        private static void BuildSchema(Configuration config)
        {
            // delete the existing db on each run
            if (File.Exists(DbFile))
                File.Delete(DbFile);

            // this NHibernate tool takes a configuration (with mapping info in)
            // and exports a database schema from it
            new SchemaExport(config)
                .Create(false, true);
        }

        public static void BuildOutDatabase()
        {
            var sessionFactory = CreateBuildSessionFactory();

            using (var session = sessionFactory.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    var atst = new AssaultItem
                                   {
                                       Description = "AT-ST 1123",
                                       LoadValue = 6,
                                       Type = "AT-ST"
                                   };
                    var squad1 = new AssaultItem
                                     {
                                         Description = "Stormtrooper Squad 213",
                                         LoadValue = 4,
                                         Type = "Stormtrooper"
                                     };

                    session.SaveOrUpdate(atst);
                    session.SaveOrUpdate(squad1);

                    transaction.Commit();
                }
            }
        }

        protected override void Before_each()
        {
            BuildOutDatabase();
        }

    }

    public class When_using_the_assault_item_repository_to_get_all_items : And_setting_up_the_temporary_database
    {
        private IRepository<AssaultItem> _repo;
        private IList<AssaultItem> _result;

        protected override void Before_each()
        {
            base.Before_each();
            _repo = new Repository<AssaultItem>(CreateSessionFactory());
        }

        protected override void Because()
        {
            _result = _repo.GetAll();
        }

        [Test]
        public void then_the_list_should_not_be_empty()
        {
            _result.Count.ShouldBeGreaterThan(0);
        }

        [Test]
        public void then_the_list_should_contain_two_items()
        {
            _result.Count.ShouldEqual(2);
        }
    }

    public class When_using_the_assault_item_repository_to_get_an_item : And_setting_up_the_temporary_database
    {
        private IRepository<AssaultItem> _repo;
        private AssaultItem _item;
        private AssaultItem _result;

        protected override void Before_each()
        {
            base.Before_each();
            _repo = new Repository<AssaultItem>(CreateSessionFactory());
            _item = _repo.GetAll()[0];
        }

        protected override void Because()
        {
            _result = _repo.GetById(_item.Id);
        }

        [Test]
        public void then_the_result_item_should_not_be_null()
        {
            _result.ShouldNotBeNull();
        }
    }

    public class When_using_the_product_repository_to_search_for_projects : And_setting_up_the_temporary_database
    {
        private ProductRepository _repo;
        private PagedSearchResult<Product> _searchResults;

        protected override void Before_each()
        {
            base.Before_each();
            _repo = new ProductRepository();
        }

        protected override void Because()
        {
            _searchResults =
                _repo.SearchProducts(new SearchParameters() {Ascending = true, Count = 2, Page = 1, SortColumn = "Name"});
        }

        [Test]
        public void then_the_returned_list_should_be_sorted_and_paged_as_requested()
        {
            _searchResults.Count.ShouldEqual(2);
        }
    }

    public class When_adding_a_new_assault_item : And_setting_up_the_temporary_database
    {
        private IRepository<AssaultItem> _repo;
        private AssaultItem _newItem;
        private int _result;
        private IList<AssaultItem> _list;

        protected override void Before_each()
        {
            base.Before_each();
            _repo = new Repository<AssaultItem>(CreateSessionFactory());
            _newItem = new AssaultItem
                           {
                               Description = "Shock Trooper Squad", 
                               Type = "Shocktrooper", 
                               LoadValue = 4
                           };
        }

        protected override void Because()
        {
            _result = _repo.Save(_newItem);
            _list = _repo.GetAll();
        }

        [Test]
        public void then_the_saved_item_should_be_have_an_id_greater_than_2()
        {
            _result.ShouldBeGreaterThan(2);
        }

        [Test]
        public void then_the_new_collection_should_contain_three_items()
        {
            _list.Count.ShouldEqual(3);
        }
    }

    public class When_editing_an_existing_item : And_setting_up_the_temporary_database
    {
        private AssaultItem _item;
        private IRepository<AssaultItem> _repo;
        private AssaultItem _savedItem;
        private string _descUpdate = "New Description For Update";

        protected override void Before_each()
        {
            base.Before_each();
            _repo = new Repository<AssaultItem>(CreateSessionFactory());
            _item = _repo.GetById(2);
            _item.Description = _descUpdate;
        }

        protected override void Because()
        {
            _repo.Update(_item);
            _savedItem = _repo.GetById(2);
        }

        [Test]
        public void then_the_saved_item_should_have_the_updated_data()
        {
            _savedItem.Description.ShouldEqual(_descUpdate);
        }
    }

    public class When_removing_an_item_from_the_assault_items : And_setting_up_the_temporary_database
    {
        private AssaultItem _itemToDelete;
        private IRepository<AssaultItem> _repo;

        protected override void Before_each()
        {
            base.Before_each();
            _repo = new Repository<AssaultItem>(CreateSessionFactory());
            _itemToDelete = _repo.GetById(1);
        }

        protected override void Because()
        {
            _repo.Delete(_itemToDelete);
        }

        [Test]
        public void then_the_list_should_be_one_item()
        {
            _repo.GetAll().Count.ShouldEqual(1);
        }
    }
}
