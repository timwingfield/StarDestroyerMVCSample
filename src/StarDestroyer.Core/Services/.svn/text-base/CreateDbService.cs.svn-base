using System.Collections.Generic;
using System.Configuration;
using System.IO;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Tool.hbm2ddl;
using StarDestroyer.Core.Entities;
using Configuration = NHibernate.Cfg.Configuration;

namespace StarDestroyer.Core.Services
{
    public class CreateDbService
    {
        static string dbFile = ConfigurationManager.AppSettings["DBFile"] as string;

        public int CreateDb()
        {
            var sessionFactory = CreateSessionFactory();

            using (var session = sessionFactory.OpenSession())
            {
                using (var trx = session.BeginTransaction())
                {
                    #region trooplist

                    var troopList = new List<AssaultItem>
                                        {
                                            new AssaultItem
                                                {
                                                    Description = "2 Shock Troopers, 6 Stormtroopers",
                                                    LoadValue = 4,
                                                    Type = "Shock Trooper Support Squad"
                                                },
                                            new AssaultItem
                                                {
                                                    Description = "5 Dark Troopers",
                                                    LoadValue = 4,
                                                    Type = "Dark Trooper Sqaud"
                                                },
                                            new AssaultItem
                                                {
                                                    Description = "8 Scout Troopers",
                                                    LoadValue = 4,
                                                    Type = "Scout Trooper Sqaud"
                                                },
                                            new AssaultItem
                                                {
                                                    Description = "Speeder Bike and 1 Scout Trooper",
                                                    LoadValue = 2,
                                                    Type = "Speeder Bike"
                                                },
                                            new AssaultItem
                                                {
                                                    Description = "Heavy Blaster and 2 Stormtroopers",
                                                    LoadValue = 1,
                                                    Type = "Heavy Blaster"
                                                },
                                            new AssaultItem
                                                {
                                                    Description = "AT-ST and pilot",
                                                    LoadValue = 6,
                                                    Type = "AT-ST"
                                                }
                                        };

                    var shockTroopers = new AssaultItem
                                            {
                                                Description = "6 Shock Troopers",
                                                LoadValue = 4,
                                                Type = "Shock Trooper Sqaud"
                                            };
                    var stormtroopers = new AssaultItem
                                            {
                                                Description = "9 Stormtroopers",
                                                LoadValue = 4,
                                                Type = "Standard Stormtrooper Sqaud"
                                            };

                    #endregion

                    foreach (var item in troopList)
                    {
                        session.SaveOrUpdate(item);
                    }

                    for (int i = 0; i < 11; i++)
                    {
                        var s = new LandingShip { Designation = string.Format("LS11{0}", i), Deployed = false };
                        session.SaveOrUpdate(s);
                    }

                    var landingShip = new LandingShip { Deployed = true, Designation = "LS1138" };
                    landingShip.AddAssaultItem(shockTroopers);
                    landingShip.AddAssaultItem(stormtroopers);

                    session.SaveOrUpdate(landingShip);

                    var products = new List<Product>()
                                       {
                                           new Product()
                                               {
                                                   Description = "Not your daddy's light saber.",
                                                   InStock = true,
                                                   Name = "Asajj Ventress Force FX Saber",
                                                   Price = 29.99m,
                                                   ShortName = "ForceFXSaber"
                                               },
                                           new Product()
                                               {
                                                   Description = "A replica of the original.",
                                                   InStock = true,
                                                   Name = "Anakin Skywalker Lightsaber",
                                                   Price = 32.99m,
                                                   ShortName = "SkywalkerLightsaber"
                                               },
                                           new Product()
                                               {
                                                   Description = "The perfect balance of weight and performance.",
                                                   InStock = true,
                                                   Name = "Ahsoka Lightsaber",
                                                   Price = 12.99m,
                                                   ShortName = "AhsokaLightsaber"
                                               },                                           
                                            new Product()
                                               {
                                                   Description = "Secure your battleship with one of the finest.",
                                                   InStock = false,
                                                   Name = "Senate Security Clone",
                                                   Price = 22.99m,
                                                   ShortName = "SenateSecurityClone"
                                               },
                                            new Product()
                                               {
                                                   Description = "Bring in the big guns.",
                                                   InStock = true,
                                                   Name = "Alliance Tank Droid",
                                                   Price = 44.99m,
                                                   ShortName = "AllianceTankDrois"
                                               },
                                            new Product()
                                               {
                                                   Description = "Turbo means better!.",
                                                   InStock = true,
                                                   Name = "Clone Wars Turbo Tank",
                                                   Price = 994.99m,
                                                   ShortName = "CloneWarsTank"
                                               },
                                       };

                    foreach (var product in products)
                    {
                        session.SaveOrUpdate(product);
                    }

                    trx.Commit();


                }

            }

            int count;

            using (var session = sessionFactory.OpenSession())
            {
                using (var trx = session.BeginTransaction())
                {
                    var items = session.CreateCriteria(typeof(AssaultItem)).List<AssaultItem>();
                    count = items.Count;
                }
            }

            return count;
        }

        private static ISessionFactory CreateSessionFactory()
        {
            return Fluently.Configure()
                .Database(SQLiteConfiguration.Standard
                    .UsingFile(dbFile))
                .Mappings(m =>
                    m.FluentMappings.AddFromAssemblyOf<AssaultItem>())
                    .ExposeConfiguration(BuildSchema)
                .BuildSessionFactory();
        }

        private static void BuildSchema(Configuration config)
        {
            // delete the existing db on each run
            if (File.Exists(dbFile))
                File.Delete(dbFile);

            // this NHibernate tool takes a configuration (with mapping info in)
            // and exports a database schema from it
            new SchemaExport(config)
                .Create(false, true);
        }
    }
}