using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using NotowaniaMVC.Infrastructure.Database.Mappings;

namespace NotowaniaMVC.Infrastructure.Database.Create
{
    public class CreateDatabase
    {
        private ISessionFactory _sessionFactory;
        private ISession _session;
        private ITransaction _transaction;
        private Configuration _cfg; 
        string connectionString = "datasource=192.168.48.21;database=D:\\BAZA\\test.fb;userid=sysdba;password=masterkey";

        public CreateDatabase()
        {
            _cfg = new Configuration();
        }

        public void CreateDB() //todo configure, create sessionFactory, CreateSession
        {
            var firebirdConfiguration = new FirebirdConfiguration();

            var configuration = Fluently.Configure()
               .Database(firebirdConfiguration.ConnectionString(connectionString).ShowSql)
                    .Mappings(m => m.FluentMappings.AddFromAssemblyOf<UnitsMap>())
                    .Mappings(m => m.FluentMappings.AddFromAssemblyOf<RegionsMap>())
                    .Mappings(m => m.FluentMappings.AddFromAssemblyOf<DocumentsMap>())
                    .Mappings(m => m.FluentMappings.AddFromAssemblyOf<CompaniesMap>())
                    .Mappings(m => m.FluentMappings.AddFromAssemblyOf<FuelsMap>())
                    .Mappings(m => m.FluentMappings.AddFromAssemblyOf<PriceListsMap>())
                    .Mappings(m => m.FluentMappings.AddFromAssemblyOf<QuotationsMap>())
               .BuildConfiguration();

            var exporter = new SchemaExport(configuration);
            exporter.Execute(true, true, false); 
        }  
    }
}
