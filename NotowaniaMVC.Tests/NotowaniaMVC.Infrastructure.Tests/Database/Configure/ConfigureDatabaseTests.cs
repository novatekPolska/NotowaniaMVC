using NUnit.Framework;
using NotowaniaMVC.Infrastructure.Database.DBConfiguration;

namespace NotowaniaMVC.Tests.NotowaniaMVC.Infrastructure.Tests.Database.Configure
{ 
    [TestFixture]
    public class ConfigureDatabaseTests
    {
        public ConfigureDatabaseTests()
        { 
        }

        private TestContext testContextInstance; 
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }
          
        [Test]
        public void when_try_to_get_session_factory_database_configuration_should_not_fail()
        {
            DatabaseConfiguration cfg = new DatabaseConfiguration();
            var session = cfg.GetSession();
        }
    }
}
