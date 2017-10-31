using NHibernate;
using NotowaniaMVC.Infrastructure.Database.DBConfiguration;
using NotowaniaMVC.Infrastructure.Database.ExistingEntities;
using NotowaniaMVC.Infrastructure.Dictionaries;
using NotowaniaMVC.Infrastructure.Dictionaries.Repositories;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace NotowaniaMVC.Tests.NotowaniaMVC.Infrastructure.Tests.Dictionaries.Repositories
{
    [TestFixture]
    public class UnitsRepositoryTests
    {
        ISession session;
        DatabaseConfiguration dbConfiguration;
        UnitsRepository unitsRepository;
         
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

        public UnitsRepositoryTests()
        {
            dbConfiguration = new DatabaseConfiguration();
            session = dbConfiguration.GetSession();
            unitsRepository = new UnitsRepository(session);
        }

        [Test]
        public void can_get_fuel_units_dictionary()
        {
            IQueryable<Dictionary> dictionary = unitsRepository.GetAllIdNamePairs();
            Assert.Greater(dictionary.Count(), 0);
        }
    }
}
