using NHibernate;
using NotowaniaMVC.Infrastructure.Database.DBConfiguration;
using NotowaniaMVC.Infrastructure.Dictionaries;
using NotowaniaMVC.Infrastructure.Dictionaries.Repositories;
using NUnit.Framework;
using System.Linq;

namespace NotowaniaMVC.Tests.NotowaniaMVC.Infrastructure.Tests.Dictionaries.Repositories
{
    [TestFixture]
    public class QuotationTypesRepositoryTests
    {
        ISession session;
        DatabaseConfiguration dbConfiguration;
        QuotationTypesRepository quotationTypesRepository;

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

        public QuotationTypesRepositoryTests()
        {
            dbConfiguration = new DatabaseConfiguration();
            session = dbConfiguration.GetSession();
            quotationTypesRepository = new QuotationTypesRepository(session);
        }

        [Test]
        public void can_get_quotation_dictionary()
        {
            IQueryable<Dictionary> dictionary = quotationTypesRepository.GetAllIdNamePairs();
            Assert.Greater(dictionary.Count(), 0);
        }
    }
}
