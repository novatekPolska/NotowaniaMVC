using NHibernate;
using NotowaniaMVC.Infrastructure.Database.DBConfiguration;
using NotowaniaMVC.Infrastructure.Dictionaries;
using NotowaniaMVC.Infrastructure.Dictionaries.Repositories;
using NUnit.Framework;
using System.Linq;

namespace NotowaniaMVC.Tests.NotowaniaMVC.Infrastructure.Tests.Dictionaries.Repositories
{  
    [TestFixture]
    public class FuelTypesRepositoryTests
    {
        ISession session;
        DatabaseConfiguration dbConfiguration;
        FuelTypesRepository fuelTypesRepository;

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

        public FuelTypesRepositoryTests()
        {
            dbConfiguration = new DatabaseConfiguration();
            session = dbConfiguration.GetSession();
            fuelTypesRepository = new FuelTypesRepository(session);
        }

        [Test]
        public void can_get_fuel_types_dictionary()
        {
            var dictionary = fuelTypesRepository.GetAllIdNamePairs();
            Assert.Greater(dictionary.Count(), 0);
        }
    }
}
