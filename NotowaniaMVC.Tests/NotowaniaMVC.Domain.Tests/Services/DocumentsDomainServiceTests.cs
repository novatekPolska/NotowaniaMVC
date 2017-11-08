using Moq;
using NotowaniaMVC.Domain.Documents.Helpers;
using NotowaniaMVC.Domain.Documents.Mappers;
using NotowaniaMVC.Domain.Documents.Services;
using NotowaniaMVC.Domain.DomainEntities;
using NotowaniaMVC.Infrastructure.Common.Interfaces;
using NotowaniaMVC.Infrastructure.Database.Entities;
using NUnit.Framework; 
using System.IO;

namespace NotowaniaMVC.Tests.NotowaniaMVC.Domain.Tests.Services
{
    [TestFixture]
    public class DocumentsDomainServiceTests
    {
        private readonly DocumentsDomainService _documentsDomainService;
        private readonly Mock<INHibernateUniversalRepository<XXX_R55_Documents>> _nhibernateUniversalRepository;
        private readonly DbDocumentsHelper _dbDocumentsHelper;
        private readonly DiskDocumentsHelper _diskDocumentsHelper;
        private readonly DocumentToDocumentDbMapper _documentMapper;


        public DocumentsDomainServiceTests()
        {
            _nhibernateUniversalRepository = new Mock<INHibernateUniversalRepository<XXX_R55_Documents>>();
            _documentMapper = new DocumentToDocumentDbMapper();
            _dbDocumentsHelper = new DbDocumentsHelper(_nhibernateUniversalRepository.Object, _documentMapper);
            _diskDocumentsHelper = new DiskDocumentsHelper();
            _documentsDomainService = new DocumentsDomainService(_dbDocumentsHelper, _diskDocumentsHelper);
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
        public void when_try_to_add_correct_document_then_method_should_create_document_on_disk_and_database_with_correct_link()
        {
            Stream file = File.OpenRead("C:/Users/szklarek/Documents/Funkcje-logiczne w Excelu.pdf");
            _documentsDomainService.SaveNewDocument(CreateFakeDocument(), "test.pdf", file);
            file.Close();
            file.Flush();
        }

        [Test]
        public void when_try_to_add_incorrect_document_then_method_should_return_error_and_should_not_add_document_on_disk_and_database()
        {
            Stream file = File.OpenRead("C:/Users/szklarek/Documents/Funkcje-logiczne w Excelu.pdf");
            var doc = Document.Factory.Create("test", "test", "", 1, 1, new object());
            _documentsDomainService.SaveNewDocument(doc, "test.pdf", file);
            file.Close();
            file.Flush();
        }

        private Document CreateFakeDocument()
        {
            return Document.Factory.Create("test", "test", "C:/Users/szklarek/Documents/Funkcje-logiczne w Excelu.pdf", 1, 1, new object());

        }
    }
}
