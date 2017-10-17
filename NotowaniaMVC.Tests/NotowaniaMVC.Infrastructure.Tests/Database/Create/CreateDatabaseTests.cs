using NUnit.Framework;
using NotowaniaMVC.Infrastructure.Database.DBConfiguration;
using NotowaniaMVC.Infrastructure.Database.Create;

namespace NotowaniaMVC.Tests.NotowaniaMVC.Infrastructure.Tests.Database.Create
{
   
    [TestFixture]
    public class CreateDatabaseTests
    {
        public CreateDatabaseTests()
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
        public void Create_database()
        {
            CreateDatabase create = new CreateDatabase();
            create.CreateDB();
        }
    }
}
