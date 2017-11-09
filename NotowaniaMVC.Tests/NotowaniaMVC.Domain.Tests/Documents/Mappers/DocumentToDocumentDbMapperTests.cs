using Moq;
using NotowaniaMVC.Domain.Documents.Helpers;
using NotowaniaMVC.Domain.Documents.Mappers;
using NotowaniaMVC.Domain.Documents.Services;
using NotowaniaMVC.Domain.DomainEntities;
using NotowaniaMVC.Infrastructure.Common.Interfaces;
using NotowaniaMVC.Infrastructure.Database.Entities;
using NUnit.Framework;
using System.IO;

namespace NotowaniaMVC.Tests.NotowaniaMVC.Domain.Tests.Documents.Mappers
{
    [TestFixture]
    public class DocumentToDocumentDbMapperTests
    {
        private DocumentToDocumentDbMapper mapper;
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

        public DocumentToDocumentDbMapperTests()
        {
            mapper = new DocumentToDocumentDbMapper();
        }

        [Test]
        public void can_map_document()
        {
            var test = mapper.Map(Document.Factory.Create("test", "test", "test", 1, 1, new object()));
        }

    }
}
