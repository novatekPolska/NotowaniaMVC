using NHibernate;
using NotowaniaMVC.Infrastructure.Database.DBConfiguration;
using NotowaniaMVC.Infrastructure.Dictionaries;
using NotowaniaMVC.Infrastructure.Dictionaries.Repositories;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace NotowaniaMVC.Tests.NotowaniaMVC.Infrastructure.Tests.Dictionaries.Repositories
{
    [TestFixture]
    public class CurrencyRepositoryTests
    {
        ISession session;
        DatabaseConfiguration dbConfiguration;
        CurrencyRepository currencyRepository;

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

        public CurrencyRepositoryTests()
        {
            dbConfiguration = new DatabaseConfiguration();
            session = dbConfiguration.GetSession();
            currencyRepository = new CurrencyRepository(session);
        }

        [Test]
        public void can_get_currency_dictionary()
        {
            Dictionary<int,string> dictionary = currencyRepository.GetAllIdNamePairs();
            var list = dictionary.ToList();
            Assert.Greater(list.Count(), 0);
        }
    }
}
