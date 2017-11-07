using NHibernate;
using NotowaniaMVC.Infrastructure.Database.DBConfiguration;
using NotowaniaMVC.Infrastructure.Database.Entities;  
using NUnit.Framework;
using System;
using NUnit;
using NotowaniaMVC.Infrastructure.Common.Repositories;

namespace NotowaniaMVC.Tests.NotowaniaMVC.Infrastructure.Tests.Documents.Repositories
{
    [TestFixture]
    public class DocumentsRepositoryTests
    { 
        ISession session;
        DatabaseConfiguration dbConfiguration;
        NHibernateUniversalRepository<XXX_R55_Documents> documentsRepository;

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
        XXX_R55_Documents fakeDocument ;

        public DocumentsRepositoryTests()
        {
            dbConfiguration = new DatabaseConfiguration();
            session = dbConfiguration.GetSession();
            documentsRepository = new NHibernateUniversalRepository<XXX_R55_Documents>(session);
            fakeDocument = CreateFakeDocument();
        }

        [Test]
        public void can_add_new_document()
        {
            documentsRepository.Create(fakeDocument); 

            var addedDocument = documentsRepository.GetById(fakeDocument.Id);

            Assert.AreEqual(fakeDocument.Guid, addedDocument.Guid);
            Assert.AreEqual(fakeDocument.Code, addedDocument.Code);
            Assert.AreEqual(fakeDocument.Created, addedDocument.Created);
            Assert.AreEqual(fakeDocument.Link, addedDocument.Link);
            Assert.AreEqual(fakeDocument.Quotation, addedDocument.Quotation);
            Assert.AreEqual(fakeDocument.Creator, addedDocument.Creator);
            //Assert.AreNotEqual(fakeDocument.Modified, addedDocument.Modified);

            documentsRepository.DeleteById(fakeDocument.Id);
        }

        [Test] 
        public void when_try_to_add_new_document_with_empty_link_then_method_should_return_error()
        {
            fakeDocument.Link = null; 
            var ex = Assert.Throws<Exception>(() => documentsRepository.Create(fakeDocument));  
        }

        [Test]
        public void when_try_to_add_new_document_with_empty_blob_then_method_should_return_error()
        {
            //fakeDocument.Blob = null;
            var ex = Assert.Throws<Exception>(() => documentsRepository.Create(fakeDocument));
        }

        [Test]
        public void when_try_to_add_document_with_empty_quotation_id_then_method_should_not_return_error()
        {
            fakeDocument.Quotation = null;
            documentsRepository.Create(fakeDocument);
            documentsRepository.DeleteById(fakeDocument.Id);
        }

        [Test]
        public void when_try_to_set_quotation_id_in_document_then_method_should_not_return_error()
        {
            fakeDocument.Quotation.Id = 1;
            documentsRepository.Create(fakeDocument);
            documentsRepository.DeleteById(fakeDocument.Id);
        }

        [Test]
        public void can_update_document()
        {
            documentsRepository.Create(fakeDocument);
            var addedDocument = documentsRepository.GetById(fakeDocument.Id);

            addedDocument.Link = "D:/";
            documentsRepository.Update(addedDocument);

            var updatedDocument = documentsRepository.GetById(fakeDocument.Id);
            Assert.AreEqual(updatedDocument.Guid, addedDocument.Guid);
            Assert.AreEqual(updatedDocument.Code, addedDocument.Code);
            Assert.AreEqual(updatedDocument.Created, addedDocument.Created);
            Assert.AreEqual(updatedDocument.Link, "D:/");
            Assert.AreEqual(updatedDocument.Quotation, addedDocument.Quotation);
            Assert.AreEqual(updatedDocument.Creator, addedDocument.Creator);
          //  Assert.AreNotEqual(updatedDocument.Modified, addedDocument.Modified);

            documentsRepository.DeleteById(fakeDocument.Id);
        }

        [Test]
        public void when_try_to_update_document_with_incorrect_data_then_method_should_return_error()
        {
            throw (new Exception("Niezaimplementowane"));
        }

        //to bedzie udostepniane tylko w sekcji administracyjnej
        [Test]
        public void can_delete_document_by_id()
        {
            documentsRepository.Create(fakeDocument);
            documentsRepository.DeleteById(fakeDocument.Id);
        }

        //to bedzie udostepniane tylko w sekcji administracyjnej
        [Test]
        public void can_delete_document_by_guid()
        {
            documentsRepository.Create(fakeDocument);
            documentsRepository.DeleteByGuid(fakeDocument.Guid); 
        }

        [Test]
        public void can_set_document_state_as_deleted()
        {
            throw(new Exception("Niezaimplementowane"));
        } 

        private XXX_R55_Documents CreateFakeDocument()
        {
            return new XXX_R55_Documents()
            {
                Guid = System.Guid.NewGuid(),
                Code = "test",
                Created = System.DateTime.Now,
                Modified = System.DateTime.Now,
                Link = "c:/" 
            };
        }
    }
}
