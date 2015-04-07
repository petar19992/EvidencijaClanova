using System;
using System.Collections.Generic;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using FluentNHibernate.Mapping;
using System.IO;
using EvidencijaClanova.Mapiranja;

namespace EvidencijaClanova
{
    public class DataLayer
    {
        private static ISessionFactory _factory = null;

        private static string _dbFile = "EvidencijaClanova.db";

        //funkcija na zahtev otvara sesiju
        public static ISession GetSession()
        {
            //ukoliko session factory nije kreiran
            if (_factory == null)
            {
                _factory = CreateSessionFactory();
            }

            return _factory.OpenSession();
        }

        //konfiguracija i kreiranje session factory
        private static ISessionFactory CreateSessionFactory()
        {
            //return Fluently.Configure()
            //    .Database(SQLiteConfiguration.Standard.UsingFile(_dbFile))
            //    .Mappings(m => m.FluentMappings.AddFromAssemblyOf<ClanMap>())
            //    .ExposeConfiguration(CreateDatabase)
            //    .BuildSessionFactory();

            return Fluently.Configure()
                .Database(SQLiteConfiguration.Standard.UsingFile(_dbFile))
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<ClanMap>())
                .BuildSessionFactory();
        }

        //po potrebi se kreira baza
        private static void CreateDatabase(Configuration config)
        {
             //pri svakom pokretanju brise se baza
            if (File.Exists(_dbFile))
                File.Delete(_dbFile);

            // this NHibernate tool takes a configuration (with mapping info in)
            // and exports a database schema from it
            new SchemaExport(config)
              .Create(false, true);
        }
    }
}
