using NotowaniaMVC.Domain.DomainEntities;
using NotowaniaMVC.Infrastructure.Database.Entities;
using NUnit.Framework; 
using Moq;
using NotowaniaMVC.Infrastructure.Common.Interfaces;
using NotowaniaMVC.Domain.Documents.Helpers; 
using NotowaniaMVC.Domain.Documents.Mappers;

namespace NotowaniaMVC.Tests.NotowaniaMVC.Domain.Tests.Helpers
{
    public class DbDocumentsHelperTests
    {
        Document document;
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

        private readonly Mock<INHibernateUniversalRepository<XXX_R55_Documents>> _nhibernateUniversalRepository;
        private readonly DbDocumentsHelper _dbDocumentsHelper;
        private readonly DocumentToDocumentDbMapper _documentMapper;

        public DbDocumentsHelperTests()
        {
            _nhibernateUniversalRepository = new Mock<INHibernateUniversalRepository<XXX_R55_Documents>>();
            _documentMapper = new DocumentToDocumentDbMapper();
            _dbDocumentsHelper = new DbDocumentsHelper(_nhibernateUniversalRepository.Object, _documentMapper);
            document = CreateFakeDocument();
        }

        [Test]
        public void when_try_to_save_incorrect_document_then_method_should_not_save_doc_and_should_return_error()
        {
            document = Document.Factory.Create("test", "test", "", 1, 1, new object());
            var validationResult = _dbDocumentsHelper.SaveDocumentToDb(document);
            Assert.AreEqual(validationResult.IsValid, false);
        }

        [Test]
        public void when_try_to_save_correct_document_then_method_should_not_return_error()
        {
            var validationResult = _dbDocumentsHelper.SaveDocumentToDb(document);
            Assert.AreEqual(validationResult.IsValid, true);
        }

        private Document CreateFakeDocument()
        {
            return Document.Factory.Create("test", "test", "C:/Users/szklarek/Documents/Funkcje-logiczne w Excelu.pdf", 1, 1, new object());
        }
    }
}
