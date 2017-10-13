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

        string connectionString = ""; //skąd wziąć connection string? 

        public CreateDatabase()
        {
            _cfg = new Configuration();
            _sessionFactory = _cfg.BuildSessionFactory();
            _session = _sessionFactory.OpenSession();
            _transaction = _session.BeginTransaction();
        }

        private void Create(string connectionString)
        {
            var configuration = Fluently.Configure() .Database(MsSqlConfiguration.MsSql2005.ConnectionString(connectionString).ShowSql)
                    .Mappings(m => m.FluentMappings.AddFromAssemblyOf<UnitsMap>())
                    .Mappings(m => m.FluentMappings.AddFromAssemblyOf<RegionsMap>())
                    .Mappings(m => m.FluentMappings.AddFromAssemblyOf<DocumentsMap>())
                    .Mappings(m => m.FluentMappings.AddFromAssemblyOf<CompaniesMap>())
                    .Mappings(m => m.FluentMappings.AddFromAssemblyOf<FuelsMap>())
                    .Mappings(m => m.FluentMappings.AddFromAssemblyOf<PriceListsMap>())
                    .Mappings(m => m.FluentMappings.AddFromAssemblyOf<QuotationsMap>())
                    .BuildConfiguration();

            var vbdriver = new NHibernate.Driver.FirebirdClientDriver();
           var dbCon= vbdriver.CreateConnection();
            //dbCon.ConnectionString
            //vbdriver.
                   

            var exporter = new SchemaExport(configuration);
            exporter.Execute(true, true, false);

            _sessionFactory = configuration.BuildSessionFactory();
        } 
    }
}
