using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using NotowaniaMVC.Infrastructure.Database.ExistingEntities;
using NotowaniaMVC.Infrastructure.Database.ExistingEntitiesMappings;
using NotowaniaMVC.Infrastructure.Database.Mappings;

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
                    .Mappings(m => m.FluentMappings.AddFromAssemblyOf<UnitsMap>())
                    .Mappings(m => m.FluentMappings.AddFromAssemblyOf<RegionsMap>())
                    .Mappings(m => m.FluentMappings.AddFromAssemblyOf<DocumentsMap>())
                    .Mappings(m => m.FluentMappings.AddFromAssemblyOf<CompaniesMap>())
                    .Mappings(m => m.FluentMappings.AddFromAssemblyOf<FuelsMap>())
                    .Mappings(m => m.FluentMappings.AddFromAssemblyOf<FuelTypesMap>())
                    .Mappings(m => m.FluentMappings.AddFromAssemblyOf<PriceListsMap>())
                    .Mappings(m => m.FluentMappings.AddFromAssemblyOf<QuotationsMap>())
                    .Mappings(m => m.FluentMappings.AddFromAssemblyOf<QuotationTypesMap>())
                    .Mappings(m => m.FluentMappings.AddFromAssemblyOf<WalutaMap>())
                    .Mappings(m => m.FluentMappings.AddFromAssemblyOf<CardGroupsMap>())
                    .Mappings(m => m.FluentMappings.AddFromAssemblyOf<DictionaryMap>())
                    .Mappings(m => m.FluentMappings.AddFromAssemblyOf<CardGroupsMap>())
                    .Mappings(m => m.FluentMappings.AddFromAssemblyOf<DictionaryTypeMap>()) 
                    .Mappings(m => m.FluentMappings.AddFromAssemblyOf<ForTableMap>())
                    .Mappings(m => m.FluentMappings.AddFromAssemblyOf<CardGroupTypesMap2>())
                    .Mappings(m => m.FluentMappings.AddFromAssemblyOf<StCardGroupTypesMap>())  
               .BuildConfiguration();
              
            var sessionFactory =  configuration.BuildSessionFactory();
            var session = sessionFactory.OpenSession();
            return session; 
        }
    }
}
