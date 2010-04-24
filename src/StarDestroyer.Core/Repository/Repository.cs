using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Linq.Expressions;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using StarDestroyer.Core.Entities;
using NHibernate.Linq;

namespace StarDestroyer.Core.Repository
{
    public interface IRepository<T>
    {
        T GetById(int Id);
        int Save(T entity);
        void Update(T entity);
        void Delete(T entity);
        IList<T> GetAll();
        List<T> Where(Expression<Func<T, bool>> whereClause);
    }

    public class Repository<T> : IRepository<T>
    {
        protected ISessionFactory _sessionFactory;

        public Repository() : this(CreateSessionFactory()) { }

        public Repository(ISessionFactory sessionFactory)
        {
            _sessionFactory = sessionFactory;
        }

        public List<T> Where(Expression<Func<T, bool>> whereClause)
        {
            using (var session = _sessionFactory.OpenSession())
            {
                return session.Linq<T>().Where(whereClause).ToList();
            }
        }

        public T GetById(int Id)
        {
            using (var session = _sessionFactory.OpenSession())
            {
                return session.Get<T>(Id);
            }
        }

        public int Save(T entity)
        {
            using (var session = _sessionFactory.OpenSession())
            {
                return (int)session.Save(entity);
            }
        }

        public void Update(T entity)
        {
            using (var session = _sessionFactory.OpenSession())
            {
                session.SaveOrUpdate(entity);
                session.Flush();
            }
        }

        public void Delete(T entity)
        {
            using (var session = _sessionFactory.OpenSession())
            {
                session.Delete(entity);
                session.Flush();
            }
        }

        public IList<T> GetAll()
        {
            using (var session = _sessionFactory.OpenSession())
            {
                return session.CreateCriteria(typeof(T)).List<T>();
            }
        }

        protected static ISessionFactory CreateSessionFactory()
        {
            string dbFile = ConfigurationManager.AppSettings["DBFile"] as string;

            return Fluently.Configure()
                .Database(SQLiteConfiguration.Standard
                    .UsingFile(dbFile))
                .Mappings(m =>
                    m.FluentMappings.AddFromAssemblyOf<AssaultItem>())
                .BuildSessionFactory();
        }
    }
}