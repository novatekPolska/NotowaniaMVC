using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using NotowaniaMVC.Infrastructure.Database.Mappings;
using System; 

namespace NotowaniaMVC.Infrastructure.Database.DBConfiguration
{
    public class DatabaseConfiguration
    { 
        private Configuration _cfg; 
        string connectionString = "datasource=192.168.48.21;database=D:\\BAZA\\test.fb;userid=sysdba;password=masterkey"; 

        public DatabaseConfiguration()
        {
            _cfg = new Configuration(); 
        }
         
        public ISession GetSession() //todo configure, create sessionFactory, CreateSession
        {
            var firebirdConfiguration = new FirebirdConfiguration();
            
            var configuration =  Fluently.Configure()
               .Database(firebirdConfiguration.ConnectionString(connectionString).ShowSql) 
               .BuildConfiguration();

            var exporter = new SchemaExport(configuration);
            exporter.Execute(true, true, false);

            var sessionFactory =  configuration.BuildSessionFactory();
            var session = sessionFactory.OpenSession();
            return session; 
        }
    }
}
