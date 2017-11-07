using NHibernate;
using NotowaniaMVC.Domain.Documents.Validators;
using NotowaniaMVC.Domain.DomainEntities;
using NotowaniaMVC.Infrastructure.Common.Repositories;
using NotowaniaMVC.Infrastructure.Database.DBConfiguration;
using NotowaniaMVC.Infrastructure.Database.Entities;
using NUnit.Framework;
using System;
using System.Linq;

namespace NotowaniaMVC.Tests.NotowaniaMVC.Domain.Tests.Documents.Validators
{
    [TestFixture]
    public class DocumentValidatorTests
    {
        DocumentValidator validator;
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

        public DocumentValidatorTests()
        {
            validator = new DocumentValidator(); 
        }
        
        [Test]
        public void when_validate_document_with_empty_link_then_validator_should_return_error()
        {
            document = Document.Factory.Create("test", "", 1, 1, 1, new object());
            var result = validator.Validate(document);
            Assert.AreEqual(result.IsValid, false);
        }

        [Test]
        public void when_validate_document_with_empty_blob_then_validator_should_return_error()
        {
            document = Document.Factory.Create("test", "C:/Users/szklarek/Documents/Funkcje-logiczne w Excelu.pdf", 1, 1, 1, null);
            var result = validator.Validate(document);
            Assert.AreEqual(result.IsValid, false);
        }

        [Test]
        public void when_validate_correct_document_then_validator_should_not_return_error()
        {
            document = Document.Factory.Create("test", "C:/Users/szklarek/Documents/Funkcje-logiczne w Excelu.pdf", 1, 1, 1, new object());
            var result = validator.Validate(document);
            Assert.AreEqual(result.IsValid, true);
        }

        [Test]
        public void when_validate_correct_document_with_empty_quotation_id_then_validator_should_not_return_error()
        {
            throw (new Exception("niezaimplementowane"));
        }

        [Test]
        public void when_validate_document_with_incorrect_link_then_validator_should_return_error()
        {
            document = Document.Factory.Create("test", "d:/Users/szklarek/Documents/testtest.pdf", 1, 1, 1, new object());
            var result = validator.Validate(document);
            Assert.AreEqual(result.IsValid, false);
        }
         
    }
}
